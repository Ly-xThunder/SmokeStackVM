namespace SmokeStackVM.Analysis

module CFGRecovery =
    type CFGEdges<'TAddress> =
        | Unary of TrueNode:'TAddress
        | Binary of TrueNode:'TAddress * FalseNode:'TAddress
        | None

    type CFGNode<'TAddress, 'TExpressions> = {
        Address: 'TAddress;
        Label: string;
        Expressions: 'TExpressions;
        OutgoingEdges: CFGEdges<'TAddress>
    }

    type CFG<'TAddress, 'TExpressions> = CFGNode<'TAddress, 'TExpressions> list