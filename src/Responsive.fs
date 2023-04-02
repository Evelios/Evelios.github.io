module App.Responsive

open System
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
let private minBrowserSize = { Tablet = 600.; Desktop = 1024. }

/// Get the browser width after a browser resize event.
let private browserWidth () : float =
    if not <| isNullOrUndefined window.innerWidth then
        window.innerWidth
    else if
        not <| isNullOrUndefined document.documentElement
        && not <| isNullOrUndefined document.documentElement.clientWidth
    then
        document.documentElement.clientWidth
    else
        document.getElementsByTagName("body").[0].clientWidth

/// Get the device that the browser is running on.
let device () : Device =
    match browserWidth () with
    | width when width > minBrowserSize.Desktop -> Desktop
    | width when width > minBrowserSize.Tablet -> Tablet
    | _ -> Mobile



let subscription (msg: Device -> 'Msg) (dispatch: 'Msg -> unit) : IDisposable =
    let response _ = device () |> msg |> dispatch
    window.onresize <- response

    { new IDisposable with
        member x.Dispose() =
            printfn "Browser Resize Subscription Disposed" }


/// Subscribe to browser resize events to get the current browser size.
/// This helps with responsive design because you get the current device
/// that the application is running on
let subscribe (msg: Device -> 'Msg) : Subscribe<'Msg> = subscription msg



/// Subscribe to browser resize events to get the current browser size.
/// This helps with responsive design because you get the current device
/// that the application is running on
let onBrowserResize (msg: Device -> 'Msg) (_: 'Model) : Sub<'Msg> =
    [ [ "browser-resize" ], subscription msg ]
