module App.Components.Body

open Feliz
open Feliz.Bulma

let section (name: string) (content: ReactElement) : ReactElement =
    let title = Bulma.title [ title.is1; prop.text name; text.hasTextCentered ]
    Bulma.section [ title; content ]
