namespace SmokeStackVMTests

open Xunit

open SmokeStackVM.Analysis.PatternFinder

module PatternFinderTests =

    [<Fact>]
    let ``FindNextPattern can find at least 2 occurences of a pattern`` () =
        let Pattern = [| Some 0x00uy; None; None; Some 0x01uy; |]
        let SearchSpace = [| 
            Some 0x00uy; Some 0x00uy; Some 0x01uy; None;
            Some 0x00uy; None; None; Some 0x01uy;
            Some 0x00uy; None; None; Some 0x00uy;
            None; None; Some 0x01uy; Some 0x00uy;
            None; Some 0x01uy; Some 0x00uy; Some 0x00uy;
        |]
        let CorrectOffsets = [| 4; 11; |]
        let firstSearchResult = FindNextPattern (Pattern, SearchSpace, 0)
        let foundFirstPattern = match firstSearchResult with
                                | Some firstOffset -> Array.exists (fun offset -> offset = firstOffset) CorrectOffsets
                                | None -> false
        let secondSearchResult = FindNextPattern (Pattern, SearchSpace, firstSearchResult.Value + 1)
        let foundSecondPattern = match secondSearchResult with
                                    | Some secondOffset -> Array.exists (fun offset -> offset = secondOffset) CorrectOffsets
                                    | None -> false
        Assert.True(foundFirstPattern && foundSecondPattern)