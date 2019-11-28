namespace SmokeStackVM.Analysis

open PatternFinder

module CFGRecovery =
    type CFGEdges<'TAddress> =
        | UnaryEdge of TrueNode:'TAddress
        | BinaryEdge of TrueNode:'TAddress * FalseNode:'TAddress
        | NoEdge

    type CFGNode<'TAddress, 'TExpressions> = {
        Address: 'TAddress;
        Label: string;
        Expressions: 'TExpressions;
        OutgoingEdges: CFGEdges<'TAddress>
    }

    type CFG<'TAddress, 'TExpressions> = CFGNode<'TAddress, 'TExpressions> list

    let private bytePatternComparer (searchSpace:array<_>, pattern:array<_>) =
        let rec compareAndCount (searchSpace:array<_>, pattern:array<_>, matchesCount) =
            if searchSpace.Length > 0 then
                if (searchSpace.[0] = pattern.[0]) || pattern.[0] = None then
                    compareAndCount (Array.tail searchSpace, Array.tail pattern, matchesCount + 1)
                else
                    matchesCount
            else
                matchesCount
        compareAndCount (searchSpace, pattern, 0) = searchSpace.Length