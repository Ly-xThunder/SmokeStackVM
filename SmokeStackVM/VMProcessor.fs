namespace SmokeStackVM

module VMProcessor =
    type OperandType =
        | ImmediateOp
        | RegisterOp
        | NoneOp

    type InstructionClass =
        | StackOp
        | ArithmeticOp
        | BinaryOp
        | ComparsionOp
        | EqualityOp
        | BranchOp
        | DataMovementOp
        | UnknownOp

    type InstructionSpec = {
        Opcode: byte
        Mnemonic: string
        OperandType: OperandType
        InstructionClass: InstructionClass
    }

    let CalculateInstructionSize instruction = if instruction.OperandType <> NoneOp then 2uy else 1uy

open VMProcessor
module VMProcessorSpec =
    type Register =
        | r1 = 0
        | r2 = 1
        | sp = 2
        | pc = 3

    let PushInstruction : InstructionSpec = { Opcode = 0uy; Mnemonic = "push"; OperandType = ImmediateOp; InstructionClass = StackOp; }
    let PopInstruction : InstructionSpec = { Opcode = 1uy; Mnemonic = "pop"; OperandType = NoneOp; InstructionClass = StackOp }
    let AddInstruction : InstructionSpec = { Opcode = 2uy; Mnemonic = "add"; OperandType = NoneOp; InstructionClass = ArithmeticOp; }
    let SubInstruction : InstructionSpec = { Opcode = 3uy; Mnemonic = "sub"; OperandType = NoneOp; InstructionClass = ArithmeticOp; }
    let RorInstruction : InstructionSpec = { Opcode = 4uy; Mnemonic = "ror"; OperandType = NoneOp; InstructionClass = BinaryOp; }
    let RolInstruction : InstructionSpec = { Opcode = 5uy; Mnemonic = "rol"; OperandType = NoneOp; InstructionClass = BinaryOp; }
    let XorInstruction : InstructionSpec = { Opcode = 6uy; Mnemonic = "xor"; OperandType = NoneOp; InstructionClass = BinaryOp; }
    let NotInstruction : InstructionSpec = { Opcode = 7uy; Mnemonic = "not"; OperandType = NoneOp; InstructionClass = BinaryOp; }
    let EqInstruction : InstructionSpec = { Opcode = 8uy; Mnemonic = "eq"; OperandType = NoneOp; InstructionClass = EqualityOp; }
    let IfInstruction : InstructionSpec = { Opcode = 9uy; Mnemonic = "if"; OperandType = NoneOp; InstructionClass = ComparsionOp; }
    let BrInstruction : InstructionSpec = { Opcode = 10uy; Mnemonic = "br"; OperandType = NoneOp; InstructionClass = BranchOp; }
    let StoreInstruction : InstructionSpec = { Opcode = 11uy; Mnemonic = "store"; OperandType = RegisterOp; InstructionClass = DataMovementOp; }
    let LoadInstruction : InstructionSpec = { Opcode = 12uy; Mnemonic = "load"; OperandType = RegisterOp; InstructionClass = DataMovementOp; }
    let NopInstruction : InstructionSpec = { Opcode = 13uy; Mnemonic = "nop"; OperandType = NoneOp; InstructionClass = UnknownOp; }

    let VMInstructionSet : InstructionSpec [] = [|
        PushInstruction
        PopInstruction
        AddInstruction
        SubInstruction
        RorInstruction
        RolInstruction
        XorInstruction
        NotInstruction
        EqInstruction
        IfInstruction
        BrInstruction
        StoreInstruction
        LoadInstruction
        NopInstruction
    |]