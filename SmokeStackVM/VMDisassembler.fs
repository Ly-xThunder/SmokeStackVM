namespace SmokeStackVM

module PCTracking =
    type TrackingMode =
        | Linear
        | Recursive

    type PCTrackingInformation = {
        CurrentPC: uint32
        EndPC: uint32
        TrackingMode: TrackingMode
    }

open VMProcessor
open VMProcessorSpec
open PCTracking
module VMDisassembler =
    type DisassembledInstruction = {
        Instruction: InstructionSpec
        Operand: string
        Address: uint32
        Blob: byte []
    }
    
    let Disassemble (blob:byte [], instructionAddress:uint32) =
        let PC = 0
        let Opcode = blob.[PC]
        if (int Opcode) > (VMInstructionSet.Length - 1) then Error (sprintf "Illegal instruction opcode: 0x%X at 0x%X" Opcode instructionAddress) else
        let DecodedInstruction = VMInstructionSet.[int Opcode]
        if (DecodedInstruction.OperandType = RegisterOp || DecodedInstruction.OperandType = ImmediateOp) && (blob.Length < 2) then
            Error (sprintf "Illegal instruction length: %d at 0x%X" blob.Length instructionAddress)
        else
            let (InstructionOperand:string, InstructionBlob:byte []) =
                match DecodedInstruction.OperandType with
                    | RegisterOp -> enum<Register>(int32 blob.[PC + 1]).ToString(), blob.[PC .. PC + 1]
                    | ImmediateOp -> (uint32 blob.[PC + 1]).ToString(), blob.[PC .. PC + 1]
                    | NoneOp -> "", blob.[PC .. PC]
            let DisassembledInstruction : DisassembledInstruction = {
                Instruction = DecodedInstruction
                Operand = InstructionOperand
                Address = instructionAddress
                Blob = InstructionBlob
                }
            Ok DisassembledInstruction

    let DisassembleLinearly (blob:byte []) =
        let rec DisassembleUsingTailCall (blob:byte [], pcTrackingInfo : PCTrackingInformation, disassembly: DisassembledInstruction list) =
            if pcTrackingInfo.CurrentPC <= pcTrackingInfo.EndPC then
                let DisasmOutput = Disassemble (blob.[int pcTrackingInfo.CurrentPC .. ], pcTrackingInfo.CurrentPC)
                match DisasmOutput with
                    | Ok disasmInstruction ->
                        let InstructionSize = CalculateInstructionSize disasmInstruction.Instruction
                        let UpdatedPCTrackingInfo = { 
                            pcTrackingInfo with
                                CurrentPC = pcTrackingInfo.CurrentPC + (uint32 InstructionSize);
                        }
                        DisassembleUsingTailCall (blob, UpdatedPCTrackingInfo , List.append disassembly [ disasmInstruction ])
                    | Error errorMessage -> Error errorMessage
            else
                Ok disassembly

        let PCTrackingInfo : PCTrackingInformation = {
            CurrentPC = 0u;
            EndPC = uint32 blob.Length - 1u;
            TrackingMode = Linear;
        }
        DisassembleUsingTailCall (blob, PCTrackingInfo, List.Empty)