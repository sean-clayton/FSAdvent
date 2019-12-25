namespace Advent.Y2019

open Advent.Common.Project

module Day2 =
    type Program = int array

    let input = parseFileLinesBy "../InputFiles/Day2.txt" (fun s -> s.Split(',') |> Array.map int) |> Seq.head

    let rec executeProgram index (program: Program) =
        let operation = program.[index]
        let x = program.[program.[index + 1]]
        let y = program.[program.[index + 2]]
        let resultIndex = program.[index + 3]
        let nextIndex = index + 4

        match operation with
        | 1 ->
            program.[resultIndex] <- x + y
            executeProgram nextIndex program
        | 2 ->
            program.[resultIndex] <- x * y
            executeProgram nextIndex program
        | _ -> ()

    let runPart2 noun verb =
        let program = Array.copy input
        program.[1] <- noun
        program.[2] <- verb

        executeProgram 0 program

        match program.[0] with
        | 19690720 -> Some (100 * noun + verb)
        | _ -> None

    let part1 () =
        let program = Array.copy input
        program.[1] <- 12
        program.[2] <- 2

        executeProgram 0 program
        program.[0]

    let part2 () =
        [0..99] |> Seq.collect (fun noun ->
            [0..99] |> Seq.map (fun verb -> runPart2 noun verb)) |> Seq.pick id