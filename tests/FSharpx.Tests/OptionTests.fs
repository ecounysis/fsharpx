﻿module FSharpx.Tests.OptionTests

open System
open NUnit.Framework
open FSharpx
open FSharpx.Option

[<Test>]
let ``kleisli composition``() =
    let f x = 
        if x > 5
            then Some "hello"
            else None
    let g x =
        if x = "hello"
            then Some 10
            else None

    let h = f >=> g
    Assert.AreEqual(Some 10, h 8)
    Assert.AreEqual(None, h 1)
    ()

[<Test>]
let ``from bool and value``() =
    let parse x = 
        Int32.TryParse(x, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) 
        |> Option.fromBoolAndValue
    Assert.AreEqual(Some 34, parse "34")
    Assert.AreEqual(None, parse "xx")
