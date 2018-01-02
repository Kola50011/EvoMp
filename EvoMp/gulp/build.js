const gulp = require('gulp')                        // General Gulp
const webpack = require('webpack')                  // Build Typescript Client/Web
const ts = require('gulp-typescript')               // Build Typescript Web
const pug = require('gulp-pug')                     // Build Pug
const htmlmin = require('gulp-htmlmin')             // Build HTML
const sass = require('gulp-sass')                   // Build SCSS
const inlinesource = require('gulp-inline-source')  // Inline Files
const cssnano = require('gulp-cssnano')             // Optimise CSS
const del = require('del')                          // Clean .temp and dist
const imagemin = require('gulp-imagemin')           // Minify Images
const uglify = require('gulp-uglify')               // Minify JavaScript
const license = require('gulp-header-license')      // Copyright Header
const fs = require('fs')                            // NodeJS FileSystem

const copyrightHeader = fs.readFileSync('LICENSE', 'utf8')

gulp.task('clean', () => {
  return Promise.all([
    del([
      '.temp'
    ]),
    del([
      './dist'
    ], {force: true})
  ])
})

gulp.task('cp', () => {
  return gulp.src('./dist/**/*.*')
    .pipe(gulp.dest('../../GT-MP Server/resources/evorp/dist'))
})


gulp.task('buildTypeScriptClient', done => {
  let compiler = webpack(require('../webpack.config.js'))

  compiler.run((err, stats) => {
    if (err) {
      console.error(err)
      return
    }

    console.log('')
    console.log(stats.toString({
      chunks: false,  // Makes the build much quieter
      colors: true    // Shows colors in the console
    }))
    console.log('')

    done()
  })
})

gulp.task('buildTypeScriptWeb', () => {
  var tsResult = gulp.src('./src/!(Fonts|Shared)*.Web/*.ts')
    .pipe(ts({
      module: 'none',
      strictNullChecks: true,
      target: 'es5',
      noImplicitAny: true,
      lib: ['ES2015', 'DOM', 'ScriptHost']
    }))


  return tsResult.pipe(uglify())
    .pipe(gulp.dest('.temp'))
})

gulp.task('copyImages', () => {
  return gulp.src('./src/!(Fonts|Shared)*.Web/images/*')
    .pipe(imagemin())
    .pipe(gulp.dest('./dist'))
})

gulp.task('copyFonts', () => {
  return gulp.src('./src/Fonts.Web/*.+(woff|woff2|ttf|svg)')
    .pipe(gulp.dest('./dist/Fonts.Web'))
})

gulp.task('buildPug', () => {
  return gulp.src('./src/!(Fonts|Shared)*.Web/*.pug')
    .pipe(pug())
    .pipe(gulp.dest('.temp'))
})

gulp.task('buildSCSS', () => {
  return gulp.src('./src/*.Web/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('.temp'))
})

gulp.task('optimiseCSS', () => {
  return gulp.src('.temp/!(Fonts|Shared)*.Web/*.css')
    .pipe(cssnano())
    .pipe(gulp.dest('.temp'))
})

gulp.task('inlineCopyHTML', () => {
  return gulp.src('.temp/!(Fonts|Shared)*/*.html')
    .pipe(inlinesource())
    .pipe(htmlmin())
    .pipe(license(copyrightHeader))
    .pipe(gulp.dest('./dist'))
})

gulp.task('build', gulp.series('clean', gulp.parallel(
  'buildTypeScriptClient', 'copyImages', 'copyFonts',
  gulp.series(
    gulp.parallel('buildTypeScriptWeb', 'buildPug', gulp.series('buildSCSS', 'optimiseCSS')),
    'inlineCopyHTML'
  ), 'cp')
))
