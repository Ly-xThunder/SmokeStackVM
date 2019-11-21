module VMDisassemblerTests
    open System
    open Xunit

    open SmokeStackVM.VMProcessor
    open SmokeStackVM.VMProcessorSpec
    open SmokeStackVM.VMDisassembler
    
    open VMDisassemblerTestSuite

    [<Fact>]
    let ``Push Instruction is disassembled correctly`` () =
        let CorrectPushTestCase = (DisassembleFunctionTestCases
                        |> Array.filter (fun testCase -> testCase.Caption = "PushInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledPush = Disassemble (CorrectPushTestCase.Data, 0x00u)
        Assert.True(DisassembledPush.Instruction.Opcode = PushInstruction.Opcode
        && DisassembledPush.Operand = CorrectPushTestCase.Data.[1].ToString()
        )

    [<Fact>]
    let ``Pop Instruction is disassembled correctly`` () =
        let CorrectPopTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "PopInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledPop = Disassemble (CorrectPopTestCase.Data, 0x00u)
        Assert.True(DisassembledPop.Instruction.Opcode = PopInstruction.Opcode
        && DisassembledPop.Operand = CorrectPopTestCase.Data.[1].ToString()
        )
    
    [<Fact>]
    let ``Add Instruction is disassembled correctly`` () =
        let CorrectAddTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "AddInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledAdd = Disassemble (CorrectAddTestCase.Data, 0x00u)
        Assert.True(DisassembledAdd.Instruction.Opcode = AddInstruction.Opcode)

    [<Fact>]
    let ``Sub Instruction is disassembled correctly`` () =
        let CorrectSubTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "SubInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledSub = Disassemble (CorrectSubTestCase.Data, 0x00u)
        Assert.True(DisassembledSub.Instruction.Opcode = SubInstruction.Opcode)

    [<Fact>]
    let ``Ror Instruction is disassembled correctly`` () =
        let CorrectRorTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RorInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledRor = Disassemble (CorrectRorTestCase.Data, 0x00u)
        Assert.True(DisassembledRor.Instruction.Opcode = RorInstruction.Opcode)

    [<Fact>]
    let ``Rol Instruction is disassembled correctly`` () =
        let CorrectRolTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RolInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledRol = Disassemble (CorrectRolTestCase.Data, 0x00u)
        Assert.True(DisassembledRol.Instruction.Opcode = RolInstruction.Opcode)

    [<Fact>]
    let ``Xor Instruction is disassembled correctly`` () =
        let CorrectXorTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "XorInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledXor = Disassemble (CorrectXorTestCase.Data, 0x00u)
        Assert.True(DisassembledXor.Instruction.Opcode = XorInstruction.Opcode)

    [<Fact>]
    let ``Not Instruction is disassembled correctly`` () =
        let CorrectNotTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NotInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledNot = Disassemble (CorrectNotTestCase.Data, 0x00u)
        Assert.True(DisassembledNot.Instruction.Opcode = NotInstruction.Opcode)

    [<Fact>]
    let ``Eq Instruction is disassembled correctly`` () =
        let CorrectEqTestCase = (DisassembleFunctionTestCases
                |> Array.filter (fun testCase -> testCase.Caption = "EqInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledEq = Disassemble (CorrectEqTestCase.Data, 0x00u)
        Assert.True(DisassembledEq.Instruction.Opcode = EqInstruction.Opcode)

    [<Fact>]
    let ``If Instruction is disassembled correctly`` () =
        let CorrectIfTestCase = (DisassembleFunctionTestCases
                |> Array.filter (fun testCase -> testCase.Caption = "IfInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledIf = Disassemble (CorrectIfTestCase.Data, 0x00u)
        Assert.True(DisassembledIf.Instruction.Opcode = IfInstruction.Opcode)

    [<Fact>]
    let ``Br Instruction is disassembled correctly`` () =
        let CorrectBrTestCase = (DisassembleFunctionTestCases
                |> Array.filter (fun testCase -> testCase.Caption = "BrInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledBr = Disassemble (CorrectBrTestCase.Data, 0x00u)
        Assert.True(DisassembledBr.Instruction.Opcode = BrInstruction.Opcode)

    [<Fact>]
    let ``Store Instruction is disassembled correctly`` () =
        let CorrectStoreTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "StoreInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledStore = Disassemble (CorrectStoreTestCase.Data, 0x00u)
        Assert.True(DisassembledStore.Instruction.Opcode = StoreInstruction.Opcode
        && DisassembledStore.Operand = enum<Register>(int32 CorrectStoreTestCase.Data.[1]).ToString()
        )

    [<Fact>]
    let ``Load Instruction is disassembled correctly`` () =
        let CorrectLoadTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "LoadInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledLoad = Disassemble (CorrectLoadTestCase.Data, 0x00u)
        Assert.True(DisassembledLoad.Instruction.Opcode = LoadInstruction.Opcode
        && DisassembledLoad.Operand = enum<Register>(int32 CorrectLoadTestCase.Data.[1]).ToString()
        )

    [<Fact>]
    let ``Nop Instruction is disassembled correctly`` () =
        let CorrectNopTestCase = (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NopInstruction" && testCase.Category = CorrectlyEncodedInstruction)).[0]
        let DisassembledNop = Disassemble (CorrectNopTestCase.Data, 0x00u)
        Assert.True(DisassembledNop.Instruction.Opcode = NopInstruction.Opcode)