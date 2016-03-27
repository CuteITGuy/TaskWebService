/// <reference path="jquery-2.2.1.js" />

function HttpVerb() {
    var createUrl = function (url, data) {
        return typeof data === "object" ? url + "?" + $.param(data) : url + "/" + data;
    };

    this.ajax = function (url, method, data, success, error, complete) {
        $.ajax({
            url: url,
            method: method,
            data: data,
            success: success,
            error: error,
            complete: complete
        });
    };

    this.delete = function (url, data, success, error, complete) {
        this.ajax(createUrl(url, data), "DELETE", null, success, error, complete);
    };

    this.get = function (url, data, success, error, complete) {
        this.ajax(url, "GET", data, success, error, complete);
    };

    this.post = function (url, data, success, error, complete) {
        this.ajax(url, "POST", data, success, error, complete);
    };

    this.put = function (url, data, success, error, complete) {
        this.ajax(url, "PUT", data, success, error, complete);
    };
}

var $http = new HttpVerb();

/*var $http = {
    ajax: function (url, method, data, success, error, complete) {
        $.ajax({
            url: url,
            method: method,
            data: data,
            success: success,
            error: error,
            complete: complete
        });
    },

    delete: function (url, data, success, error, complete) {

        this.ajax(url, "DELETE", null, success, error, complete);
    },

    get: function (url, data, success, error, complete) {
        this.ajax(url, "GET", data, success, error, complete);
    },

    post: function (url, data, success, error, complete) {
        this.ajax(url, "POST", data, success, error, complete);
    },

    put: function (url, data, success, error, complete) {
        this.ajax(url, "PUT", data, success, error, complete);
    }
}*/