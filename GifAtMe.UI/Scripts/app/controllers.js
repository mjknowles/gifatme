'use strict';

/* Controllers */

var gifAtMeControllers = angular.module('gifAtMeControllers', []);

/*phonecatControllers.controller('PhoneListCtrl', ['$scope', 'Phone',
  function ($scope, Phone) {
      $scope.phones = Phone.query();
      $scope.orderProp = 'age';
  }]);
  */

/*phonecatControllers.controller('PhoneDetailCtrl', ['$scope', '$routeParams', 'Phone',
  function ($scope, $routeParams, Phone) {
      $scope.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
          $scope.mainImageUrl = phone.images[0];
      });

      $scope.setImage = function (imageUrl) {
          $scope.mainImageUrl = imageUrl;
      }
  }]);
 */
gifAtMeControllers.controller('GifsCtrl', ['$scope', 'Gif',
  function ($scope, Gif) {
      Gif.get(function (resp) {
          $scope.users = [];

          // Create normalized list of users and their gifs
          var flags = [], l = resp.GifEntries.length, i;
          for (i = 0; i < l; i++) {
              var user = {
                  name: "",
                  gifs: []
              };
              if (flags[resp.GifEntries[i].UserName]) continue;
              flags[resp.GifEntries[i].UserName] = true;
              user.name = resp.GifEntries[i].UserName
              $scope.users.push(user);
          }

          var ul = $scope.users.length, j;
          for (i = 0; i < ul; i++) {
              for (j = 0; j < l; j++) {
                  if (resp.GifEntries[j].UserName === $scope.users[i].name) {
                      $scope.users[i].gifs.push(resp.GifEntries[j]);
                  }
              }
          }

          // Set initial user filter
          $scope.userFilter = "mknowles";

      });
  }]);
