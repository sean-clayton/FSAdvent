namespace Advent.Common

open System
open System.IO

module Project =
    let projectPath =
        Directory.GetParent(Environment.CurrentDirectory).Parent.FullName

    let parseFileLinesBy path f =
        Path.Combine(projectPath, path)
        |> File.ReadLines
        |> Seq.map f
