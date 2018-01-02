const gulp = require('gulp')                        // General Gulp

gulp.task('watch', () => {
  gulp.watch('./src/*.Web/*.*', gulp.parallel('build:dev'))

  gulp.watch('./src/*.Client/*.*', gulp.series(
    'buildTypeScriptClient:dev',
    'cp'
  ))
})

gulp.task('dev', gulp.series('build:dev', 'watch'))
