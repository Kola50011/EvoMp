const gulp = require('gulp')                        // General Gulp
const webpack = require('webpack')                  // Build Typescript Client/Web
const ts = require('gulp-typescript')               // Build Typescript Web
const pug = require('gulp-pug')                     // Build Pug
const htmlmin = require('gulp-htmlmin')             // Build HTML
const sass = require('gulp-sass')                   // Build SCSS
const inlinesource = require('gulp-inline-source')  // Inline Files

gulp.task('cp', () => {
  return gulp.src('./dist/**/*.*')
    .pipe(gulp.dest('../../GT-MP Server/resources/evorp/dist'))
})

gulp.task('buildTypeScriptClient:dev', done => {
  let compiler = webpack(require('../webpack.dev.js'))

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

gulp.task('buildTypeScriptWeb:dev', () => {
  var tsResult = gulp.src('./src/!(Fonts|Shared)*.Web/*.ts')
      .pipe(ts({
        module: 'none',
        strictNullChecks: true,
        target: 'es5',
        noImplicitAny: true,
        lib: ['ES2015', 'DOM', 'ScriptHost']
      }))

  return tsResult.pipe(gulp.dest('.temp'))
})

gulp.task('copyImages:dev', () => {
  return gulp.src('./src/!(Fonts|Shared)*.Web/images/*')
    .pipe(gulp.dest('./dist'))
})

gulp.task('copyJavascript:dev', () => {
  return gulp.src('./src/*.Web/*.js')
    .pipe(gulp.dest('.temp'))
})

gulp.task('copyFonts:dev', () => {
  return gulp.src('./src/Fonts.Web/*.+(woff|woff2|ttf|svg)')
    .pipe(gulp.dest('./dist/Fonts.Web'))
})

gulp.task('buildPug:dev', () => {
  return gulp.src('./src/!(Fonts|Shared)*.Web/*.pug')
    .pipe(pug())
    .pipe(gulp.dest('.temp'))
})

gulp.task('buildSCSS:dev', () => {
  return gulp.src('./src/*.Web/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('.temp'))
})

gulp.task('inlineCopyHTML:dev', () => {
  return gulp.src('.temp/!(Fonts|Shared)*/*.html')
    .pipe(inlinesource())
    .pipe(gulp.dest('./dist'))
})

gulp.task('build:dev', gulp.series(
  gulp.parallel(
    'buildTypeScriptClient:dev', 'copyImages:dev', 'copyFonts:dev', 'copyJavascript:dev',
    gulp.series(
      gulp.parallel('buildTypeScriptWeb:dev', 'buildPug:dev', 'buildSCSS:dev'),
      'inlineCopyHTML:dev'
    )
  ), 'cp'
))
