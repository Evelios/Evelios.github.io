const path = require('path')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')

const CONFIG = {
    indexHtmlTemplate: './public/index.html',
    fsharpEntry: './src/App.fs',
    cssEntry: './src/main.sass',
    outputDir: './dist',
    assetsDir: './dist',
    devServerPort: 8080,
    // When using webpack-dev-server, you may need to redirect some calls
    // to a external API server. See https://webpack.js.org/configuration/dev-server/#devserver-proxy
    devServerProxy: undefined
};

// If we're running the webpack-dev-server, assume we're in development mode
const isProduction = !process.argv.find(v => v.indexOf('serve') !== -1);
console.log('Bundling for ' + (isProduction ? 'production' : 'development') + '...');

module.exports = {
    // In development, have two different entries to speed up hot reloading.
    // In production, have a single entry but use mini-css-extract-plugin to move the styles to a separate file.
    entry: {app: [CONFIG.cssEntry, CONFIG.fsharpEntry]},

    mode: isProduction ? 'production' : 'development',
    devtool: isProduction ? 'source-map' : 'eval-source-map',

    output: {
        path: path.resolve(__dirname, CONFIG.outputDir),
        filename: 'main.js'
    },

    // Add a hash to the output file name in production
    // to prevent browser caching if code changes
    // output: {
    //     path: path.join(__dirname, CONFIG.outputDir),
    //     filename: isProduction ? '[name].[fullhash].js' : '[name].js',
    //     devtoolModuleFilenameTemplate: info =>
    //         path.resolve(info.absoluteResourcePath).replace(/\\/g, '/'),
    // },

    // optimization: {
    //     // Split the code coming from npm packages into a different file.
    //     // 3rd party dependencies change less often, let the browser cache them.
    //     splitChunks: {
    //         cacheGroups: {
    //             commons: {
    //                 test: /node_modules/,
    //                 name: 'vendors',
    //                 chunks: 'all'
    //             }
    //         }
    //     },
    // },

    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: 'fable-loader'
        }, {
            test: /\.(sass|scss|css)$/,
            use: [
                MiniCssExtractPlugin.loader,
                'css-loader',
                'sass-loader'
            ]
        },
            {
                test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)(\?.*)?$/,
                use: ['file-loader']
            }

        ]
    },

    // Besides the HtmlPlugin, we use the following plugins:
    // PRODUCTION
    //      - MiniCssExtractPlugin: Extracts CSS from bundle to a different file
    //      - CopyWebpackPlugin: Copies static assets to output directory
    // DEVELOPMENT
    //      - HotModuleReplacementPlugin: Enables hot reloading when code changes without refreshing
    // plugins: isProduction ?
    //     commonPlugins.concat([
    //         new MiniCssExtractPlugin({filename: 'style.css'}),
    //         new CopyWebpackPlugin({
    //             patterns: [
    //                 {from: CONFIG.assetsDir}
    //             ]
    //         }),
    //     ])
    //     : commonPlugins.concat([
    //         new webpack.HotModuleReplacementPlugin(),
    //     ]),

    plugins: [
        new MiniCssExtractPlugin({filename: 'main.css'})
    ],

    // resolve: {
    //     // See https://github.com/fable-compiler/Fable/issues/1490
    //     symlinks: false
    // },

    devServer: {
        devMiddleware: {
            publicPath: '/'
        },
        port: CONFIG.devServerPort,
        proxy: CONFIG.devServerProxy,
        hot: true,
        static: {
            directory: path.resolve(__dirname, CONFIG.outputDir),
            staticOptions: {},
        },
    },
};