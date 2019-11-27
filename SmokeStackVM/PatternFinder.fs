namespace SmokeStackVM.Analysis

module PatternFinder =
    let FindNextPattern (pattern, searchSpace, startOffset) =
        let rec FindPattern (pattern:array<_>, searchSpace:array<_>, currentOffset) : option<_> =
            if currentOffset <= searchSpace.Length - 1 && searchSpace.Length >= pattern.Length then
                let slicedSearchSpace = searchSpace.[currentOffset .. (currentOffset + pattern.Length - 1)]
                if slicedSearchSpace = pattern then
                    Some (currentOffset)
                else
                    FindPattern (pattern, searchSpace, currentOffset + 1)
            else
                None
        FindPattern (pattern, searchSpace, startOffset)