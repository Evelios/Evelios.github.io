namespace App.Router

[<RequireQualifiedAccess>]
type Route =
    | Home
    | Gallery
    | Demos

/// The Router handles interactions with the URL to determine which pages need
/// to be loaded.
module Router =

    open App

    open Elmish
    open Elmish.Navigation
    open Elmish.UrlParser

    // ---- Route Locations ----

    /// Routes specifically for images.
    module Image =
        let interactive (image: Image) : string = "/img/interactive/" + image

        let gallery (image: Image) : string = "/img/gallery/" + image

    let home = "/"


    // ---- Router Parsing ----

    /// Create a new operator </> to act as a math separator.
    let inline (</>) a b = a + "/" + string b

    /// Convert a route to a string hash which is used for the URL.
    let toHash route =
        let routeUri =
            match route with
            | Route.Home -> ""
            | Route.Gallery -> "gallery"
            | Route.Demos -> "demos"

        "/#" </> routeUri

    /// Set the URL and navigate within the app to a new URL.
    let navigateTo routeOpt =
        match routeOpt with
        | Some route -> Navigation.modifyUrl (toHash route)
        | None -> Cmd.none


    /// Main router parser for the app. This hooks into the main program to
    /// handle the URL parsing for the whole single page application.
    let routeParser: Parser<Route -> Route, Route> =
        oneOf
            [ map Route.Home top
              map Route.Gallery (s "gallery")
              map Route.Demos (s "demos") ]

    /// Map URI safe characters into human readable characters
    let mapCharacters (s: string) = s.Replace("%20", " ")
