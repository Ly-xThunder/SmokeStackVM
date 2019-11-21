module VMDisassemblerTestSuite
    open Testing

    type VMDisassemblerTestCaseCategory =
        | CorrectlyEncodedInstruction
        | IncorrectlyEncodedInstruction
        | CorrectlyDisassembledInstruction
        | IncorrectlyDisassembledInstruction

    let DisassembleFunctionTestCases : TestCase<byte[], VMDisassemblerTestCaseCategory> [] = [|
        { Caption = "PushInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x00uy; 0x01uy |] }
        { Caption = "PushInstruction"; Category = IncorrectlyEncodedInstruction; Data = [| 0x00uy; |] }
        { Caption = "PopInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x01uy; 0x01uy |] }
        { Caption = "PopInstruction"; Category = IncorrectlyEncodedInstruction; Data = [| 0x01uy; |] }
        { Caption = "AddInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x02uy |] }
        { Caption = "SubInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x03uy |] }
        { Caption = "RorInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x04uy |] }
        { Caption = "RolInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x05uy |] }
        { Caption = "XorInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x06uy |] }
        { Caption = "NotInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x07uy |] }
        { Caption = "EqInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x08uy |] }
        { Caption = "IfInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x09uy |] }
        { Caption = "BrInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Auy |] }
        { Caption = "StoreInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Buy; 0x01uy |] }
        { Caption = "StoreInstruction"; Category = IncorrectlyEncodedInstruction; Data = [| 0x0Buy; |] }
        { Caption = "LoadInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Cuy; 0x01uy |] }
        { Caption = "LoadInstruction"; Category = IncorrectlyEncodedInstruction; Data = [| 0x0Cuy; |] }
        { Caption = "NopInstruction"; Category = CorrectlyEncodedInstruction; Data = [| 0x0Duy |] }
    |]