namespace SmokeStackVMTests

open Xunit

open SmokeStackVM.VMProcessor
open SmokeStackVM.VMProcessorSpec
open SmokeStackVM.VMDisassembler

open VMDisassemblerTestSuite

module VMDisassemblerTests =

    [<Fact>]
    let ``Push Instruction is disassembled correctly`` () =
        let CorrectPushTestCase = Array.head (DisassembleFunctionTestCases
                        |> Array.filter (fun testCase -> testCase.Caption = "PushEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectPushTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledPush ->
                Assert.True(disassembledPush.Instruction.Opcode = PushInstruction.Opcode
                && disassembledPush.Operand = CorrectPushTestCase.Data.[1].ToString()
                )
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Pop Instruction is disassembled correctly`` () =
        let CorrectPopTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "PopEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectPopTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledPop ->
                Assert.True(disassembledPop.Instruction.Opcode = PopInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)
    
    [<Fact>]
    let ``Add Instruction is disassembled correctly`` () =
        let CorrectAddTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "AddEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectAddTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledAdd ->
                Assert.True(disassembledAdd.Instruction.Opcode = AddInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Sub Instruction is disassembled correctly`` () =
        let CorrectSubTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "SubEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectSubTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledSub ->
                Assert.True(disassembledSub.Instruction.Opcode = SubInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Ror Instruction is disassembled correctly`` () =
        let CorrectRorTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RorEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectRorTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledRor ->
                Assert.True(disassembledRor.Instruction.Opcode = RorInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Rol Instruction is disassembled correctly`` () =
        let CorrectRolTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "RolEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectRolTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledRol ->
                Assert.True(disassembledRol.Instruction.Opcode = RolInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Xor Instruction is disassembled correctly`` () =
        let CorrectXorTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "XorEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectXorTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledXor ->
                Assert.True(disassembledXor.Instruction.Opcode = XorInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Not Instruction is disassembled correctly`` () =
        let CorrectNotTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NotEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectNotTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledNot ->
                Assert.True(disassembledNot.Instruction.Opcode = NotInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Eq Instruction is disassembled correctly`` () =
        let CorrectEqTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "EqEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectEqTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledEq ->
                Assert.True(disassembledEq.Instruction.Opcode = EqInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``If Instruction is disassembled correctly`` () =
        let CorrectIfTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "IfEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectIfTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledIf ->
                Assert.True(disassembledIf.Instruction.Opcode = IfInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Br Instruction is disassembled correctly`` () =
        let CorrectBrTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "BrEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectBrTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledBr ->
                Assert.True(disassembledBr.Instruction.Opcode = BrInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Store Instruction is disassembled correctly`` () =
        let CorrectStoreTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "StoreEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectStoreTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledStore ->
                Assert.True(disassembledStore.Instruction.Opcode = StoreInstruction.Opcode
                && disassembledStore.Operand = enum<Register>(int32 CorrectStoreTestCase.Data.[1]).ToString()
                )
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Load Instruction is disassembled correctly`` () =
        let CorrectLoadTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "LoadEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectLoadTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledLoad ->
                Assert.True(disassembledLoad.Instruction.Opcode = LoadInstruction.Opcode
                && disassembledLoad.Operand = enum<Register>(int32 CorrectLoadTestCase.Data.[1]).ToString()
                )
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Nop Instruction is disassembled correctly`` () =
        let CorrectNopTestCase = Array.head (DisassembleFunctionTestCases
                    |> Array.filter (fun testCase -> testCase.Caption = "NopEncoded" && testCase.Category = CorrectlyEncodedInstruction))
        let DisasmOutput = Disassemble (CorrectNopTestCase.Data, 0x00u)
        match DisasmOutput with
            | Ok disassembledNop ->
                Assert.True(disassembledNop.Instruction.Opcode = NopInstruction.Opcode)
            | Error errorMessage -> Assert.True(false)

    [<Fact>]
    let ``Linear sweep disassembly algorithm is implemented correctly`` () =
        let TestCaseData = DisassembleLinearlyFunctionTestCase |> Array.map (fun testCase -> testCase.Data.Blob) |> Array.concat
        let TestCaseDisassembly = List.ofArray (DisassembleLinearlyFunctionTestCase |> Array.map (fun testCase -> testCase.Data))
        let ImplementationResult = DisassembleLinearly (TestCaseData)
        match ImplementationResult with
            | Ok linearDisassembly ->
                let DisassemblyOutputsAreIdentical = List.forall2 (fun disasm1 disasm2 -> disasm1 = disasm2) TestCaseDisassembly linearDisassembly
                Assert.True(DisassemblyOutputsAreIdentical)
            | Error errorMessage -> Assert.True(false)