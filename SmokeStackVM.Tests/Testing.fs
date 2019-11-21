module Testing
    type TestCase<'TTestData, 'TTestCategory> = {
        Caption: string
        Category: 'TTestCategory
        Data: 'TTestData
    }
