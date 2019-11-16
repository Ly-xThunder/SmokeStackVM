namespace SmokeStackVM

module VMProcessor =
    type OperandType =
        | ImmediateOp
        | RegisterOp
        | NoneOp

    type InstructionSpec = {
        Opcode: byte
        Mnemonic: string
        OperandType: OperandType
    }

open VMProcessor
module VMProcessorSpec =
    type Registers =
        | PC = 0
        | SP = 1
        | R1 = 2
        | R2 = 3

    let PushInstruction : InstructionSpec = { Opcode = 0uy; Mnemonic = "push"; OperandType = ImmediateOp; }
    let PopInstruction : InstructionSpec = { Opcode = 1uy; Mnemonic = "pop"; OperandType = NoneOp; }
    let AddInstruction : InstructionSpec = { Opcode = 2uy; Mnemonic = "add"; OperandType = NoneOp; }
    let SubInstruction : InstructionSpec = { Opcode = 3uy; Mnemonic = "sub"; OperandType = NoneOp; }
    let RorInstruction : InstructionSpec = { Opcode = 4uy; Mnemonic = "ror"; OperandType = NoneOp; }
    let RolInstruction : InstructionSpec = { Opcode = 5uy; Mnemonic = "rol"; OperandType = NoneOp; }
    let XorInstruction : InstructionSpec = { Opcode = 6uy; Mnemonic = "xor"; OperandType = NoneOp; }
    let NotInstruction : InstructionSpec = { Opcode = 7uy; Mnemonic = "not"; OperandType = NoneOp; }
    let EqInstruction : InstructionSpec = { Opcode = 8uy; Mnemonic = "eq"; OperandType = NoneOp; }
    let IfInstruction : InstructionSpec = { Opcode = 9uy; Mnemonic = "if"; OperandType = NoneOp; }
    let BrInstruction : InstructionSpec = { Opcode = 10uy; Mnemonic = "br"; OperandType = NoneOp; }
    let StoreInstruction : InstructionSpec = { Opcode = 11uy; Mnemonic = "store"; OperandType = RegisterOp; }
    let LoadInstruction : InstructionSpec = { Opcode = 12uy; Mnemonic = "load"; OperandType = RegisterOp; }
    let NopInstruction : InstructionSpec = { Opcode = 13uy; Mnemonic = "nop"; OperandType = NoneOp; }