namespace SmokeStackVM.Analysis

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