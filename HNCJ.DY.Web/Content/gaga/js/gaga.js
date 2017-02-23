/**
 * Created by gaga on 2016/12/28.
 */


var app = angular.module("dyApp", ['ui.router', 'dyApp.controller']);

app.run([
    '$rootScope',
    '$state',
    '$stateParams',
    function ($rootScope, $state, $stateParams) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams
    }
]);
app.config(function ($stateProvider, $urlRouterProvider, $locationProvider, $uiViewScrollProvider) {
    //用于改变state时跳至顶部
    $uiViewScrollProvider.useAnchorScroll();
    var index = {
        name: 'content',
        url: "/index",
        views: {
            content: {
                templateUrl: 'template/content.html',
                // controller: ''
            }
        }
    };
    var help = {
        name: 'help',
        url: "/help",
        views: {
            content: {
                templateUrl: 'template/help.html',
                // controller: ''
            }
        }
    };
    var person = {
        name: 'person',
        url: "/person",
        views: {
            content: {
                templateUrl: 'template/person.html',
                // controller: ''
            }
        }
    };
    var list = [];
    data.map(function (ele, index) {
        if (ele.son.length == 0) {
            list.push(ele.ename);
            return;
        }
        ele.son.map(function (e, i) {
            list.push(e.ename);
        })
    });
    list.map(function (ele, index) {
        var ctrlName = ele.substr(0, 1).toLocaleUpperCase() + ele.substr(1);
        var htmlName = ele + '.html';
        var newState = {
            name: 'content.' + ele,
            url: '/' + ele,
            views: {
                menuList: {
                    templateUrl: 'template/' + htmlName
                }
            }
        };
        console.log(ele);
        $stateProvider.state(newState);
    });
    $stateProvider.state(index);
    $stateProvider.state(help);
    $stateProvider.state(person);
    $urlRouterProvider.otherwise('index');
});