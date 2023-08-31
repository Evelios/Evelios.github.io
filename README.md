# Website for Thomas G Waters

## Development

First of all, start with installing the project's npm dependencies
```bash
npm install
```

If you are using a Mac computer with an M1 chip run
```bash
arch -arm64 brew install llvm
sudo gem install ffi
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
