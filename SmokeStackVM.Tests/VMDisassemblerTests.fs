module VMDisassemblerTests
    open System
    open Xunit

    open SmokeStackVM.VMProcessor
    open SmokeStackVM.VMProcessorSpec
    open SmokeStackVM.VMDisassembler
    
    open VMDisassemblerTestSuite

    [<Fact>]
    let ``Push Instruction is disassembled correctly`` () =
        let DisassembledPush = Disassemble (CorrectPushBlob, 0x00u)
        Assert.True(DisassembledPush.Instruction.Opcode = PushInstruction.Opcode
        && DisassembledPush.Operand = CorrectPushBlob.[1].ToString()
        )

    [<Fact>]
    let ``Pop Instruction is disassembled correctly`` () =
        let DisassembledPop = Disassemble (CorrectPopBlob, 0x00u)
        Assert.True(DisassembledPop.Instruction.Opcode = PopInstruction.Opcode
        && DisassembledPop.Operand = CorrectPopBlob.[1].ToString()
        )
    
    [<Fact>]
    let ``Add Instruction is disassembled correctly`` () =
        let DisassembledAdd = Disassemble (CorrectAddBlob, 0x00u)
        Assert.True(DisassembledAdd.Instruction.Opcode = AddInstruction.Opcode)

    [<Fact>]
    let ``Sub Instruction is disassembled correctly`` () =
        let DisassembledSub = Disassemble (CorrectSubBlob, 0x00u)
        Assert.True(DisassembledSub.Instruction.Opcode = SubInstruction.Opcode)

    [<Fact>]
    let ``Ror Instruction is disassembled correctly`` () =
        let DisassembledRor = Disassemble (CorrectRorBlob, 0x00u)
        Assert.True(DisassembledRor.Instruction.Opcode = RorInstruction.Opcode)

    [<Fact>]
    let ``Rol Instruction is disassembled correctly`` () =
        let DisassembledRol = Disassemble (CorrectRolBlob, 0x00u)
        Assert.True(DisassembledRol.Instruction.Opcode = RolInstruction.Opcode)

    [<Fact>]
    let ``Xor Instruction is disassembled correctly`` () =
        let DisassembledXor = Disassemble (CorrectXorBlob, 0x00u)
        Assert.True(DisassembledXor.Instruction.Opcode = XorInstruction.Opcode)

    [<Fact>]
    let ``Not Instruction is disassembled correctly`` () =
        let DisassembledNot = Disassemble (CorrectNotBlob, 0x00u)
        Assert.True(DisassembledNot.Instruction.Opcode = NotInstruction.Opcode)

    [<Fact>]
    let ``Eq Instruction is disassembled correctly`` () =
        let DisassembledEq = Disassemble (CorrectEqBlob, 0x00u)
        Assert.True(DisassembledEq.Instruction.Opcode = EqInstruction.Opcode)

    [<Fact>]
    let ``If Instruction is disassembled correctly`` () =
        let DisassembledIf = Disassemble (CorrectIfBlob, 0x00u)
        Assert.True(DisassembledIf.Instruction.Opcode = IfInstruction.Opcode)

    [<Fact>]
    let ``Br Instruction is disassembled correctly`` () =
        let DisassembledBr = Disassemble (CorrectBrBlob, 0x00u)
        Assert.True(DisassembledBr.Instruction.Opcode = BrInstruction.Opcode)

    [<Fact>]
    let ``Store Instruction is disassembled correctly`` () =
        let DisassembledStore = Disassemble (CorrectStoreBlob, 0x00u)
        Assert.True(DisassembledStore.Instruction.Opcode = StoreInstruction.Opcode
        && DisassembledStore.Operand = enum<Register>(int32 CorrectStoreBlob.[1]).ToString()
        )

    [<Fact>]
    let ``Load Instruction is disassembled correctly`` () =
        let DisassembledLoad = Disassemble (CorrectLoadBlob, 0x00u)
        Assert.True(DisassembledLoad.Instruction.Opcode = LoadInstruction.Opcode
        && DisassembledLoad.Operand = enum<Register>(int32 CorrectLoadBlob.[1]).ToString()
        )

    [<Fact>]
    let ``Nop Instruction is disassembled correctly`` () =
        let DisassembledNop = Disassemble (CorrectNopBlob, 0x00u)
        Assert.True(DisassembledNop.Instruction.Opcode = NopInstruction.Opcode)