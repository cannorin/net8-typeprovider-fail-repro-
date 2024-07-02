module ReproTests

open Repro
open NUnit.Framework

let areEqual (a: 'a, b) = Assert.That(a, Is.EqualTo(b))

[<Test>]
let ``Default constructor should create instance`` () =
    areEqual ("My internal state", MyType().InnerState)

[<Test>]
let ``Constructor with parameter should create instance`` () =
    areEqual ("override", MyType("override").InnerState)

[<Test>]
let ``Method with ReflectedDefinition parameter should get its name`` () =
    let myValue = 2
    areEqual ("myValue", MyType.NameOf(myValue))

type Generative2 = Repro.GenerativeProvider<2>
type Generative4 = Repro.GenerativeProvider<4>

[<Test>]
let ``Can access properties of generative provider 2`` () =
    let obj = Generative2()
    areEqual (obj.Property1, 1)
    areEqual (obj.Property2, 2)

[<Test>]
let ``Can access properties of generative provider 4`` () =
    let obj = Generative4()
    areEqual (obj.Property1, 1)
    areEqual (obj.Property2, 2)
    areEqual (obj.Property3, 3)
    areEqual (obj.Property4, 4)
