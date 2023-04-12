module App

open Elmish
open Elmish.React
open Elmish.Navigation

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

open App
open App.Router

Program.mkProgram Index.init Index.update Index.view
|> Program.withSubscription (Responsive.onBrowserResize Index.BrowserResize)

#if DEBUG
|> Program.withConsoleTrace
#endif

|> Program.toNavigable (UrlParser.parseHash Router.routeParser) Index.setRoute
|> Program.withReactSynchronous "App"

#if DEBUG
|> Program.withDebugger
#endif

|> Program.run
