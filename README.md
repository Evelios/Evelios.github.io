# Website for Thomas G Waters

## Development

This is a simple Fable application including an [Elmish](https://elmish.github.io/) counter. The repository is made for learning purposes and the generated Javascript output is not optimized. That said, the template shows you how easy it is to get started with Fable and Elmish using minimal configuration.

## Building and running the app

First of all, start with installing the project's npm dependencies
```bash
npm install
```
Once this is finished, you can then build and compile the project:
```
npm run build
```
You can start developing the application in watch mode using the webpack development server:
```
npm start
```
After the first compilation is finished, navigate to http://localhost:8080 in your browser to see the application.

### VS Code

If you happen to use Visual Studio Code, simply hitting F5 will start the development watch mode for you and opens your default browser navigating to http://localhost:8080.

## Images


* Article Preview
    - Aspect ratio of __4:3__
    - Size of __240px__ by __180px__
* Gallery Images
    - Thumbnail should have a max width of __800px__
* Interactive Images
    - Thumbnail should have a size of __500px__ by __500px__


## Deploying

After you run `npm run build`, the contents of the `public` folder can be hosted as a static site. If you haven't hosted a static site before, I'd recommend using [Netlify](https://netlify.com) (it's free!)

### Netlify

Add a `netlify.toml` file next to this README, for standard SPA routing:

```toml
[[redirects]]
  from = "/*"
  to = "/index.html"
  status = 200
```

__Build command:__ `npm run build`

__Publish directory:__ `public`
