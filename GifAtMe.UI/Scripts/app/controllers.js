'use strict';

/* Controllers */

var gifAtMeControllers = angular.module('gifAtMeControllers', []);

gifAtMeControllers.controller('gifsCtrl', ['$scope', 'gifAtMeAPI', 'userGifs',
  function ($scope, gifAtMeAPI, userGifs) {

      // Set user gifs
      $scope.gifs.userGifs = userGifs;

      // Set initial user filter
      $scope.gifFilter.keyword = "";

      /*gifAtMeAPI.gifs.get(function (resp) {
          $scope.gifs.query = resp.GifEntries;

      });*/
  }]);