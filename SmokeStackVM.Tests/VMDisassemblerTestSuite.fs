module VMDisassemblerTestSuite
    open Testing
    open System

    open SmokeStackVM.VMProcessorSpec
    open SmokeStackVM.VMDisassembler
    [<Flags>]
    type VMDisassemblerTestCaseCategory =
        | CorrectlyEncodedInstruction
        | IncorrectlyEncodedInstruction
        | CorrectlyDisassembledInstruction
        | IncorrectlyDisassembledInstruction

    let DisassembleFunctionTestCases : TestCase<byte[], VMDisassemblerTestCaseCategory> [] = [|
        { Caption = "PushEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x00uy; 0x01uy |] }
        { Caption = "PushEncoded"; Category = IncorrectlyEncodedInstruction; Data = [| 0x00uy; |] }
        { Caption = "PopEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x01uy; 0x01uy |] }
        { Caption = "PopEncoded"; Category = IncorrectlyEncodedInstruction; Data = [| 0x01uy; |] }
        { Caption = "AddEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x02uy |] }
        { Caption = "SubEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x03uy |] }
        { Caption = "RorEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x04uy |] }
        { Caption = "RolEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x05uy |] }
        { Caption = "XorEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x06uy |] }
        { Caption = "NotEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x07uy |] }
        { Caption = "EqEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x08uy |] }
        { Caption = "IfEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x09uy |] }
        { Caption = "BrEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Auy |] }
        { Caption = "StoreEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Buy; 0x01uy |] }
        { Caption = "StoreEncoded"; Category = IncorrectlyEncodedInstruction; Data = [| 0x0Buy; |] }
        { Caption = "LoadEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Cuy; 0x01uy |] }
        { Caption = "LoadEncoded"; Category = IncorrectlyEncodedInstruction; Data = [| 0x0Cuy; |] }
        { Caption = "NopEncoded"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Duy |] }
    |]

    let DisassembleLinearlyFunctionTestCase : TestCase<DisassembledInstruction, VMDisassemblerTestCaseCategory> [] = [|
        { Caption = "PushDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = PushInstruction; Operand = "1"; Address = 0u; Blob = [| 0x00uy; 0x01uy |] } }
        { Caption = "AddDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = AddInstruction; Operand = ""; Address = 2u; Blob = [| 0x02uy |] } }
        { Caption = "RorDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = RorInstruction; Operand = ""; Address = 3u; Blob = [| 0x04uy |] } }
        { Caption = "EqDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = EqInstruction; Operand = ""; Address = 4u; Blob = [| 0x08uy |] } }
        { Caption = "BrDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = BrInstruction; Operand = ""; Address = 5u; Blob = [| 0x0Auy |] } }
        { Caption = "StoreDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = StoreInstruction; Operand = "r2"; Address = 6u; Blob = [| 0x0Buy; 0x01uy |] } }
        { Caption = "NopDisassmebled"; Category = CorrectlyDisassembledInstruction; Data = { Instruction = NopInstruction; Operand = ""; Address = 8u; Blob = [| 0x0Duy |] } }
    |]