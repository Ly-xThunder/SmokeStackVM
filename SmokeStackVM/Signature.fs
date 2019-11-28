namespace SmokeStackVM.Analysis

module Signature =
    type SyntaticCodeSignture<'TSignature> = {
        Identifier: uint32;
        Label: string;
        Signature: 'TSignature;
        ExpressionsCount: uint32;
    }
