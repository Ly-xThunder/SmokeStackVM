namespace SmokeStackVM.Analysis

module Signature =
    type SyntaticCodeSignture<'TSignature> = {
        Signature: 'TSignature;
        ExpressionsCount: uint32;
    }
