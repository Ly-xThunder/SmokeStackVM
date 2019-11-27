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
        let patternComparer (searchSpace:array<_>, pattern:array<_>) =
            let rec compareAndCount (searchSpace:array<_>, pattern:array<_>, matchesCount) =
                if searchSpace.Length > 0 then
                    if (searchSpace.[0] = pattern.[0]) || pattern.[0] = None then
                        compareAndCount (Array.tail searchSpace, Array.tail pattern, matchesCount + 1)
                    else
                        matchesCount
                else
                    matchesCount
            compareAndCount (searchSpace, pattern, 0) = searchSpace.Length

        let firstSearchResult = FindNextPattern (Pattern, SearchSpace, 0) patternComparer
        let foundFirstPattern = match firstSearchResult with
                                | Some firstOffset -> Array.exists (fun offset -> offset = firstOffset) CorrectOffsets
                                | None -> false
        let secondSearchResult = FindNextPattern (Pattern, SearchSpace, firstSearchResult.Value + 1) patternComparer
        let foundSecondPattern = match secondSearchResult with
                                    | Some secondOffset -> Array.exists (fun offset -> offset = secondOffset) CorrectOffsets
                                    | None -> false
        Assert.True(foundFirstPattern && foundSecondPattern)