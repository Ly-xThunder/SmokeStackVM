module VMDisassemblerTestSuite
    let CorrectPushBlob = [| 0x00uy; 0x01uy |]
    let IncorrectPushBlob = [| 0x00uy; |]

    let CorrectPopBlob = [| 0x01uy; 0x01uy |]
    let IncorrectPopBlob = [| 0x01uy; |]

    let CorrectAddBlob = [| 0x02uy |]

    let CorrectSubBlob = [| 0x03uy |]

    let CorrectRorBlob = [| 0x04uy |]

    let CorrectRolBlob = [| 0x05uy |]

    let CorrectXorBlob = [| 0x06uy |]

    let CorrectNotBlob = [| 0x07uy |]

    let CorrectEqBlob = [| 0x08uy |]

    let CorrectIfBlob = [| 0x09uy |]

    let CorrectBrBlob = [| 0x0Auy |]

    let CorrectStoreBlob = [| 0x0Buy; 0x01uy |]
    let IncorrectStoreBlob = [| 0x0Buy; |]

    let CorrectLoadBlob = [| 0x0Cuy; 0x01uy |]
    let IncorrectLoadBlob = [| 0x0Cuy; |]

    let CorrectNopBlob = [| 0x0Duy |]