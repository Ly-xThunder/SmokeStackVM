namespace SmokeStackVM

module PCTracking =
    type TrackingMode =
        | Linear
        | Recursive

    type PCTrackingInformation = {
        CurrentPC: uint32
        PreviousPC: uint32
        CurrentInstructionSize: byte
        EndAddress: uint32
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
        let DecodedInstruction = VMInstructionSet.[int blob.[PC]]
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
        DisassembledInstruction

    let DisassembleLinearly (blob:byte []) : DisassembledInstruction list =
        let rec DisassembleUsingTailCall (blob:byte [], pcTrackingInfo : PCTrackingInformation, disassembly: DisassembledInstruction list) =
            if pcTrackingInfo.CurrentPC <= pcTrackingInfo.EndAddress then
                let DisasmInstruction = Disassemble (blob.[int pcTrackingInfo.CurrentPC .. ], pcTrackingInfo.CurrentPC)
                let InstructionSize = if DisasmInstruction.Instruction.OperandType <> NoneOp then 2uy else 1uy
                let UpdatedPCTrackingInfo = { 
                    pcTrackingInfo with
                        CurrentPC = pcTrackingInfo.CurrentPC + (uint32 InstructionSize);
                        PreviousPC = pcTrackingInfo.CurrentPC;
                        CurrentInstructionSize = InstructionSize;
                }
                DisassembleUsingTailCall (blob, UpdatedPCTrackingInfo , List.append disassembly [ DisasmInstruction ])
            else
                disassembly

        let PCTrackingInfo : PCTrackingInformation = {
            CurrentPC = 0u;
            PreviousPC = 0u;
            CurrentInstructionSize = 1uy;
            EndAddress = uint32 blob.Length - 1u;
            TrackingMode = Linear;
        }
        DisassembleUsingTailCall (blob, PCTrackingInfo, List.Empty)