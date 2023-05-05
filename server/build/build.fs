open Fake.Core

module Command =
    [<Literal>]
    let Default = "Default"

let initTargets () =
    Target.create Command.Default (fun _ -> printfn "hello from FAKE!")

[<EntryPoint>]
let main args =
    Context.FakeExecutionContext.Create false "build.fsx" []
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    initTargets ()

    try
        match args with
        | [| target |] -> Target.runOrDefault target
        | _ -> Target.runOrDefault Command.Default
    with _ ->
        ()

    0
