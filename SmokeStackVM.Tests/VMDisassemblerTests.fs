module VMDisassemblerTests
    open System
    open Xunit

    open SmokeStackVM.VMProcessor
    open SmokeStackVM.VMProcessorSpec
    open SmokeStackVM.VMDisassembler
    
    open VMDisassemblerTestSuite

    [<Fact>]
    let ``Push Instruction is disassembled correctly`` () =
        let CorrectPushTestCase = Array.head (DisassembleFunctionTestCases
                        |> Array.filter (fun testCase -> testCase.Caption = "PushEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledPush = Disassemble (CorrectPushTestCase.Data, 0x00u)
        Assert.True(DisassembledPush.Instruction.Opcode = PushInstruction.Opcode
        && DisassembledPush.Operand = CorrectPushTestCase.Data.[1].ToString()
        )

    [<Fact>]
    let ``Pop Instruction is disassembled correctly`` () =
        let CorrectPopTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "PopEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledPop = Disassemble (CorrectPopTestCase.Data, 0x00u)
        Assert.True(DisassembledPop.Instruction.Opcode = PopInstruction.Opcode
        && DisassembledPop.Operand = CorrectPopTestCase.Data.[1].ToString()
        )
    
    [<Fact>]
    let ``Add Instruction is disassembled correctly`` () =
        let CorrectAddTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "AddEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledAdd = Disassemble (CorrectAddTestCase.Data, 0x00u)
        Assert.True(DisassembledAdd.Instruction.Opcode = AddInstruction.Opcode)

    [<Fact>]
    let ``Sub Instruction is disassembled correctly`` () =
        let CorrectSubTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "SubEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledSub = Disassemble (CorrectSubTestCase.Data, 0x00u)
        Assert.True(DisassembledSub.Instruction.Opcode = SubInstruction.Opcode)

    [<Fact>]
    let ``Ror Instruction is disassembled correctly`` () =
        let CorrectRorTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RorEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledRor = Disassemble (CorrectRorTestCase.Data, 0x00u)
        Assert.True(DisassembledRor.Instruction.Opcode = RorInstruction.Opcode)

    [<Fact>]
    let ``Rol Instruction is disassembled correctly`` () =
        let CorrectRolTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RolEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledRol = Disassemble (CorrectRolTestCase.Data, 0x00u)
        Assert.True(DisassembledRol.Instruction.Opcode = RolInstruction.Opcode)

    [<Fact>]
    let ``Xor Instruction is disassembled correctly`` () =
        let CorrectXorTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "XorEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledXor = Disassemble (CorrectXorTestCase.Data, 0x00u)
        Assert.True(DisassembledXor.Instruction.Opcode = XorInstruction.Opcode)

    [<Fact>]
    let ``Not Instruction is disassembled correctly`` () =
        let CorrectNotTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NotEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledNot = Disassemble (CorrectNotTestCase.Data, 0x00u)
        Assert.True(DisassembledNot.Instruction.Opcode = NotInstruction.Opcode)

    [<Fact>]
    let ``Eq Instruction is disassembled correctly`` () =
        let CorrectEqTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "EqEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledEq = Disassemble (CorrectEqTestCase.Data, 0x00u)
        Assert.True(DisassembledEq.Instruction.Opcode = EqInstruction.Opcode)

    [<Fact>]
    let ``If Instruction is disassembled correctly`` () =
        let CorrectIfTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "IfEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledIf = Disassemble (CorrectIfTestCase.Data, 0x00u)
        Assert.True(DisassembledIf.Instruction.Opcode = IfInstruction.Opcode)

    [<Fact>]
    let ``Br Instruction is disassembled correctly`` () =
        let CorrectBrTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "BrEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledBr = Disassemble (CorrectBrTestCase.Data, 0x00u)
        Assert.True(DisassembledBr.Instruction.Opcode = BrInstruction.Opcode)

    [<Fact>]
    let ``Store Instruction is disassembled correctly`` () =
        let CorrectStoreTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "StoreEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledStore = Disassemble (CorrectStoreTestCase.Data, 0x00u)
        Assert.True(DisassembledStore.Instruction.Opcode = StoreInstruction.Opcode
        && DisassembledStore.Operand = enum<Register>(int32 CorrectStoreTestCase.Data.[1]).ToString()
        )

    [<Fact>]
    let ``Load Instruction is disassembled correctly`` () =
        let CorrectLoadTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "LoadEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledLoad = Disassemble (CorrectLoadTestCase.Data, 0x00u)
        Assert.True(DisassembledLoad.Instruction.Opcode = LoadInstruction.Opcode
        && DisassembledLoad.Operand = enum<Register>(int32 CorrectLoadTestCase.Data.[1]).ToString()
        )

    [<Fact>]
    let ``Nop Instruction is disassembled correctly`` () =
        let CorrectNopTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NopEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisassembledNop = Disassemble (CorrectNopTestCase.Data, 0x00u)
        Assert.True(DisassembledNop.Instruction.Opcode = NopInstruction.Opcode)

    [<Fact>]
    let ``Linear sweep disassembly algorithm is implemented correctly`` () =
        let TestCaseData = Array.concat (Seq.ofArray (DisassembleLinearlyFunctionTestCase |> Array.choose (fun testCase -> Some (testCase.Data.Blob))))
        let TestCaseDisassembly = List.ofArray (DisassembleLinearlyFunctionTestCase |> Array.choose (fun testCase -> Some (testCase.Data)))
        let ImplementationResult = DisassembleLinearly (TestCaseData)
        let DisassemblyOutputsAreIdentical = List.forall2 (fun disasm1 disasm2 -> disasm1 = disasm2) TestCaseDisassembly ImplementationResult
        Assert.True(DisassemblyOutputsAreIdentical)