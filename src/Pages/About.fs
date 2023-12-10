module App.Pages.About

open Feliz
open Feliz.Bulma
open Fable.Formatting.Markdown

open App.Components

type Model =
    | NotLoaded
    | Loaded of string


type Msg = LoadedMarkdown of string

let init () : Model = NotLoaded

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | LoadedMarkdown markdown -> Loaded markdown

let view (model: Model) : ReactElement =
    match model with
    | NotLoaded -> Html.h1 "Not Loaded"
    | Loaded markdown ->
        let markdownAsHtml = Html.div []
        // TODO markdown to html
        // Html.div [ prop.dangerouslySetInnerHTML (Markdown.ToHtml markdown) ]

        // Body.section "About" markdownAsHtml
        Body.section "About" (Html.div [])
