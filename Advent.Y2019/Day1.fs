namespace Advent.Y2019

open System
open System.IO
open Advent.Common.Project

module Day1 =
    let getRequiredFuel mass =
        mass / 3 - 2

    let part1 () =
        parseFileLinesBy "../InputFiles/Day1.txt" int
        |> Seq.sumBy getRequiredFuel

    let rec getTotalFuel mass =
        match mass with
        | m when m <= 0 -> 0
        | m -> m + getTotalFuel (getRequiredFuel m)

    let getFuel mass =
        getTotalFuel (getRequiredFuel mass)

    let part2 () =
        parseFileLinesBy "../InputFiles/Day1.txt" int
        |> Seq.sumBy getFuel