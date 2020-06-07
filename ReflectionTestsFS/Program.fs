// Learn more about F# at http://fsharp.org

open System
open System.Reflection

let test (assembly : Assembly) =
    printfn "------------------------------------------------------------------------"
    let assemblyName = assembly.GetName().Name
    printfn "Testing %s" assemblyName

    let gitVersionInformationType = assembly.GetType "GitVersionInformation"
    let fields = gitVersionInformationType.GetFields()
    let properties = gitVersionInformationType.GetProperties()

    for field in fields do
        printfn "%s: %s" field.Name (field.GetValue(null) :?> string)
        
    for property in properties do
        printfn "%s: %s" property.Name (property.GetGetMethod(true).Invoke(null, null) :?> string)

    printfn ""
    printfn "Specific Field:"
    let versionField = gitVersionInformationType.GetField "Major"
    if not (isNull versionField)
    then printfn "%s" (versionField.GetValue(null) :?> string)
    else
        let versionProperty = gitVersionInformationType.GetProperty "Major"
        if not (isNull versionProperty)
        then printfn "%s" (versionProperty.GetGetMethod(true).Invoke(null, null) :?> string)
    ()

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    test typeof<ClassLibrary1.Class1>.Assembly
    test typeof<ClassLibrary2.Class1>.Assembly
    test typeof<ClassLibrary3.Class1>.Assembly
    0 // return an integer exit code

