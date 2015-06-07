'use strict';

/* Controllers */

var gifAtMeControllers = angular.module('gifAtMeControllers', []);

gifAtMeControllers.controller('gifsCtrl', ['$scope', 'gifAtMeAPI',
  function ($scope, gifAtMeAPI) {
      gifAtMeAPI.gifs.get(function (resp) {
          $scope.users = [];
          $scope.gifs.query = resp.GifEntries;

          // Create of users for picker
          var flags = [], l = resp.GifEntries.length, i;
          for (i = 0; i < l; i++) {
              if (flags[resp.GifEntries[i].UserName]) continue;
              flags[resp.GifEntries[i].UserName] = true;
              $scope.users.push(resp.GifEntries[i].UserName);
          }

          // Set initial user filter
          $scope.query = {
              UserName: "not a user",
              Keyword: ""
          };
      });
  }]);