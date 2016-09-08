/// <binding BeforeBuild='clean, min' Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("gulp-rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    rename = require("gulp-rename"),
    ngAnnotate = require("gulp-ng-annotate");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/*.js";
paths.minJs = paths.webroot + "lib/_app/*.min.js";
paths.css = paths.webroot + "css/*.css";
paths.minCss = paths.webroot + "css/*.min.css";
paths.JsDest = paths.webroot + "lib/_app";
paths.CssDest = paths.webroot + "css";

gulp.task("clean:js", function () {
    return gulp.src(paths.minJs, { read: false })
    .pipe(rimraf());
});

gulp.task("clean:css", function () {
    return gulp.src(paths.minCss, { read: false })
    .pipe(rimraf());
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs])
        .pipe(ngAnnotate())
        .pipe(uglify()).pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(paths.JsDest));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(cssmin()).pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(paths.CssDest));
});

gulp.task("min", ["min:js", "min:css"]);
