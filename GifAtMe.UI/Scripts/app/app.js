'use strict';

/* App Module */

var gifAtMeApp = angular.module('gifAtMeApp', [
  'gifAtMeControllers',
  'gifAtMeServices'
]);

/*
gifAtMeApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/', {
            templateUrl: '~/Views/Home/_UserList.cshtml',
            controller: 'GifsCtrl'
        }).
        otherwise({
            redirectTo: '/'
        });
  }]);
  */