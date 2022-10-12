module App.Responsive

open Elmish
open Fable.Core.JsInterop
open Browser.Types
open Browser

/// The device that the browser is being viewed at.
type Device =
    | Mobile
    | Tablet
    | Desktop

/// Minimum sizes of different devices
type MinBrowserSize = { Tablet: float; Desktop: float }

/// The minimum size of different devices. Everything smaller than a tablet
/// is considered to be a mobile device.
let private minBrowserSize =
    { Tablet = 600.; Desktop = 1024. }

/// Get the browser width after a browser resize event.
let private browserWidth () : float =
    if not <| isNullOrUndefined window.innerWidth then
        window.innerWidth
    else if not <| isNullOrUndefined document.documentElement
            && not
               <| isNullOrUndefined document.documentElement.clientWidth then
        document.documentElement.clientWidth
    else
        document.getElementsByTagName("body").[0]
            .clientWidth

/// Get the device that the browser is running on.
let device () : Device =
    match browserWidth () with
    | width when width > minBrowserSize.Desktop -> Desktop
    | width when width > minBrowserSize.Tablet -> Tablet
    | _ -> Mobile

/// Subscribe to browser resize events to get the current browser size.
/// This helps with responsive design because you get the current device
/// that the application is running on
let subscribe (msg: Device -> 'Msg) (_: 'State) : Cmd<'Msg> =
    let sub dispatch : unit =
        let response _ = device () |> msg |> dispatch
        window.onresize <- response

    Cmd.ofSub sub
