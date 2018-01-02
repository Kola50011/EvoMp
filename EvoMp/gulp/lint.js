const gulp = require('gulp')
const plumber = require('gulp-plumber')
const sassLint = require('gulp-sass-lint')          // Lint SCSS
const gulpTslint = require('gulp-tslint')           // Lint Typescript

const tslint = require('tslint')
const tsProg = tslint.Linter.createProgram('./tsconfig.json')

gulp.task('lintSCSS', () => {
  return gulp.src('./src/*.Web/!(_)*.scss')
    .pipe(sassLint(
      {
        options: {
          'formatter': 'stylish',
          'merge-default-rules': true
        }
      }
    ))
    .pipe(sassLint.format())
    .pipe(sassLint.failOnError())
})

gulp.task('lint', gulp.series('lintSCSS' ))
