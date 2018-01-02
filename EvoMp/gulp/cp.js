const gulp = require('gulp')                        // General Gulp

gulp.task('cp', () => {
  return gulp.src('./dist/**/*.*')
    .pipe(gulp.dest('../../GT-MP Server/resources/evorp/dist'))
})
