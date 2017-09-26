var jsl, md5, html, html2, http, login, top; login = login || (function () {
    "use strict"; var lib = {}, gXhr = null, gXhrDsl = null, gData = null, gDialog = null, gDialogContent = null, gFacErr = null, gFormElem = null, gUsernameElem = null, gPassElem = null; function showLogin() {
        if (gXhr) { gXhr.stop(); }
        jsl.setText("dialogTitle", gData.pageTitle); jsl.setText(gFacErr, ""); gFacErr = null; jsl.removeClass(gDialog, "forgotPass"); jsl.removeClass(gDialog, "pushmail"); jsl.removeClass(gDialog, "setFac"); jsl.removeClass(gDialog, "wait");
    }
    function reloadPage(href) {
        var a = html2.a({ href: href | "" }), clickEvt = null; html2.add(document.body, a); if (a.click) { a.click(); } else if (document.dispatchEvent) { clickEvt = document.createEvent("MouseEvent"); clickEvt.initEvent("click", true, true); a.dispatchEvent(clickEvt); } else if (document.fireEvent) { a.fireEvent('onclick'); }
        document.body.removeChild(a);
    }
    function ajaxWaitForBox() {
        var callback, url = encodeURI("/"), countRetries = 0, boxStillOnline = true, requestTimeout = 5000, xhr; function goToBox() { top.location.href = "/"; }
        function doRequest() { xhr = http.request({ method: "POST", url: url, params: {}, callback: callback }); xhr.start(); }
        callback = function (resp) {
            if (resp && false === resp.answer) { boxStillOnline = false; window.setTimeout(doRequest, requestTimeout); } else {
                if (boxStillOnline) {
                    countRetries += 1; if (6 < countRetries) { window.setTimeout(goToBox, 5000); }
                    window.setTimeout(doRequest, requestTimeout);
                } else { window.setTimeout(goToBox, 30000); }
            }
        }; window.setTimeout(doRequest, requestTimeout);
    }
    function createFacErr(errCode) {
        var tmpElem = null; if (!gFacErr) {
            gFacErr = html2.div({ "class": "restore" }); html2.add(gDialogContent, gFacErr); if (0 === errCode) { html2.add(gFacErr, html2.div({ id: "restore", "class": "doReset" }, html2.p({}, gData.facIsSetTxt), html2.p({}, gData.facPationsTxt), html2.div({ "class": "intxt wait" }), html2.p({}, gData.facWhatNextTxt))); ajaxWaitForBox(); window.setTimeout(function () { reloadPage(gData.fallbackRedirectUrl); }, 300000); } else {
                if (2 === errCode) { tmpElem = html2.div({ id: "restoreerror1" }, html2.p({ "class": "ErrorMsg" }, gData.txt.facNotAllowed), html2.p({}, gData.txt.facOnAllowedComp)); } else { tmpElem = html2.div({ id: "restoreerror2" }, html2.p({ "class": "ErrorMsg" }, gData.txt.facFailed), html2.p({}, gData.txt.facNotAllowedOr10Min), html2.p({}, gData.txt.facDisconnectPower), html2.p({}, gData.txt.facRepeat)); }
                html2.add(gFacErr, html2.div({ id: "restoreerror" }, html2.h4({}, gData.txt.facNotSet), tmpElem)); html2.add(gFacErr, html2.div({ id: "toOvBtn", "class": "btn_form_foot" }, html2.button({ type: "button", id: "reloadPageBtn", onclick: showLogin }, gData.txt.back)));
            }
        }
    }
    function cbSetFac(resp) { if (resp && "number" === typeof resp.restore_state) { createFacErr(resp.restore_state); } else { createFacErr(); } }
    function showFacReset() {
        if (gData.fromInternet) { showLogin(); return; }
        if (gXhr) { gXhr.stop(); }
        jsl.addClass(gDialog, "setFac"); jsl.addClass(gDialog, "wait"); jsl.setText("dialogTitle", gData.facTitle); gXhr = http.request({ method: "POST", url: "index.lua", type: "text", params: { reset: "1" }, callback: function () { jsl.removeClass(gDialog, "wait"); gXhr = http.request({ method: "POST", url: "index.lua", params: { restore: "login" }, callback: cbSetFac }); gXhr.start(); } }); gXhr.start();
    }
    function makeDots(str) {
        var newStr = "", i = 0; for (i = 0; i < str.length; i += 1) { if (255 < str.charCodeAt(i)) { newStr += "."; } else { newStr += str.charAt(i); } }
        return newStr;
    }
    function setFocus() {
        var elemToFocus = gPassElem; if (gData.activeUsers && 1 !== gData.activeUsers.length && gUsernameElem && ("" === gUsernameElem.value || gData.fromInternet)) { elemToFocus = gUsernameElem; }
        jsl.focus(elemToFocus);
    }
    function onLoginFormSubmit() {
        var dot_pass = null, resp = null; jsl.addClass("uiLoginError", "hidden"); jsl.removeClass(gPassElem, "error"); if (gUsernameElem) { if (0 < gUsernameElem.value.length) { jsl.addClass("uiUsernameError", "hidden"); jsl.removeClass(gUsernameElem, "error"); jsl.setValue("username", gUsernameElem.value); } else { jsl.removeClass("uiUsernameError", "hidden"); jsl.addClass(gUsernameElem, "error"); jsl.focus(gUsernameElem); return false; } }
        dot_pass = makeDots(gPassElem.value); resp = gData.challenge + "-" + dot_pass; jsl.setValue("uiResp", gData.challenge + "-" + md5.hex(resp)); jsl.disable(gUsernameElem); jsl.disable(gPassElem); jsl.disable("submitLoginBtn"); jsl.setStyle(gFormElem, "cursor", "wait"); return true;
    }
    function getWaitStr(mSec) {
        var sec = Math.ceil(mSec / 1000), txt = ""; if (1 === sec) { txt = gData.txt.waitOne; } else { txt = gData.txt.waitMore.replace(/%1/, sec); }
        return txt;
    }
    function doBlockLogin(blockTime) {
        var start = (new Date()).getTime(), timer = null; jsl.disable(gUsernameElem); jsl.disable("username"); jsl.disable(gPassElem); jsl.disable("submitLoginBtn"); function f() {
            var now = (new Date()).getTime(), wait = blockTime - (now - start), hiddenTime; if (timer) { window.clearTimeout(timer); }
            if (0 < wait) { jsl.setHtml("uiWait", getWaitStr(wait)); jsl.removeClass("uiLoginError", "hidden"); jsl.addClass(gPassElem, "error"); timer = window.setTimeout(f, 500); } else {
                timer = null; hiddenTime = 10000 - blockTime; if (0 >= hiddenTime) { hiddenTime = 1; }
                blockTime = 0; window.setTimeout(function () { if (!blockTime) { jsl.addClass("uiLoginError", "hidden"); } }, hiddenTime); jsl.enable(gUsernameElem); jsl.enable("username"); jsl.enable(gPassElem); setFocus(); jsl.enable("submitLoginBtn"); jsl.setHtml("uiWait", gData.txt.waitTryAgain);
            }
        }
        f();
    }
    function showPushMailSent() {
        if (gData.fromInternet) { showLogin(); return; }
        jsl.addClass(gDialog, "wait"); jsl.addClass(gDialog, "pushmail"); if (gXhr) { gXhr.stop(); }
        gXhr = http.request({ method: "POST", url: "index.lua", type: "text", params: { pushmail: "1" }, callback: function () { jsl.removeClass(gDialog, "wait"); } }); gXhr.start();
    }
    function createForgotPass() {
        var parDiv = null, tmpObj = null, tmpObj2 = null; if (gData.fromInternet) { return; }
        parDiv = html2.div({ id: "forgotPass", "class": "forgotPassForm" }); if (gData.pushmailEnabled) {
            tmpObj = html2.div({ "class": "pushmailQuestion" }, html2.h4({}, gData.txt.sendLoginLink), html2.p({}, gData.txt.loginLinkMailPossible))
            html2.add(parDiv, html2.div({ "class": "pushmailSend" }, html2.h4({}, gData.txt.sendLoginLink), html2.p({}, gData.txt.loginMailSent)), tmpObj); if (gData.firstTenMin) { html2.add(tmpObj, html2.div({ "class": "btn_form" }, html2.button({ onclick: showPushMailSent, name: "pushmail", type: "button", id: "sendPushMail" }, gData.txt.sendPushServiceMail))); html2.add(parDiv, html2.div({ id: "setFac" }, html2.hr({}), html2.h4({}, gData.txt.setFacDefaults), html2.p({}, gData.setFacTxt), html2.div({}, html2.span({ "class": "WarnMsgBold" }, gData.txt.caution), html2.p({}, gData.txt.facLoseSettings)), html2.div({ "class": "btn_form" }, html2.button({ onclick: showFacReset, name: "reset", type: "button", id: "sendFacReset" }, gData.txt.setFacDefaults)))); }
        } else {
            tmpObj = ""; if (false === gData.firstTenMin) { tmpObj = html2.p({}, gData.cutPowerTxt); }
            html2.add(parDiv, html2.div({ id: "setFac" }, html2.p({}, gData.ifSetFacTxt), html2.div({}, html2.span({ "class": "WarnMsgBold" }, gData.txt.caution), html2.p({}, gData.txt.facLoseSettings)), tmpObj));
        }
        tmpObj = ""; tmpObj2 = ""; if (gData.pushmailEnabled && false === gData.firstTenMin) { tmpObj = html2.button({ onclick: showPushMailSent, name: "pushmail", type: "button", id: "sendPushMail" }, gData.txt.sendPushServiceMail); }
        if (!gData.pushmailEnabled && gData.firstTenMin) { tmpObj2 = html2.button({ onclick: showFacReset, name: "reset", type: "button", id: "sendFacReset" }, gData.txt.setFacDefaults); }
        html2.add(parDiv, html2.div({ "class": "btn_form_foot" }, html2.button({ onclick: showLogin, type: "button", name: "cancel", id: "cancelForgotPass" }, gData.txt.back), tmpObj, tmpObj2)); html2.add(gDialogContent, parDiv);
    }
    function showForgotPass(evt) {
        if (gData.fromInternet) { return jsl.cancelEvent(evt); }
        if (!jsl.get("forgotPass")) { createForgotPass(); }
        jsl.setText("dialogTitle", gData.txt.forgotPassword); jsl.addClass(gDialog, "forgotPass"); return jsl.cancelEvent(evt);
    }
    function createLoginForm() {
        var form = null, formContent = null, formFoot = null, reasonTab = [], userOptions; formContent = html2.div({ "class": "formular" }); formFoot = html2.div({ "class": "btn_form_foot" }); form = html2.form({ method: "post", "action": "index.lua", id: "loginForm", "class": "loginForm" }, formContent, formFoot); html2.add(gDialogContent, form); if (gData.loginReason && 0 < gData.loginReason && 6 > gData.loginReason) { reasonTab = [gData.logoutTxt, gData.txt.autoLogoutTimeout, gData.changedPassTxt, gData.txt.autoLogoutLoginAgain, gData.txt.tooManyLogins]; if ("string" === typeof reasonTab[gData.loginReason]) { html2.add(formContent, html2.p({}, reasonTab[gData.loginReason])); } } else if (gData.falseUsername) { html2.add(formContent, html2.p({}, jsl.sprintf(gData.txt.notAuthorized, gData.falseUsername))); } else { if (true !== gData.showUser) { html2.add(formContent, html2.p({}, gData.txt.loginAgainPass)); } else { if (gData.fromInternet) { html2.add(formContent, html2.p({}, gData.txt.loginAgainUserMailPass)); } else { html2.add(formContent, html2.p({}, gData.txt.loginAgainUserPass)); } } }
        if (true === gData.showUser) {
            if (gData.fromInternet || "2" === gData.authMode) { gUsernameElem = html2.input({ type: "text", id: "uiViewUser", name: "uiUser", tabindex: "1", value: gData.username }); } else {
                if (1 > gData.activeUsers.length) { gUsernameElem = html2.input({ type: "text", id: "uiViewUser", name: "uiUser", tabindex: "1", value: gData.username }); } else {
                    if (gData.username) { userOptions = gData.activeUsers; } else { userOptions = [{ text: gData.txt.pleaseChoose, value: "" }].concat(gData.activeUsers); }
                    gUsernameElem = html2.selectBox({ id: "uiViewUser", name: "uiUser", selected: gData.username, options: userOptions, attr: { tabindex: "1" } });
                }
            }
            gUsernameElem.addEventListener("change", function () { if (jsl.hasClass("uiViewUser", "error") && "" !== jsl.getValue("uiViewUser")) { jsl.removeClass("uiViewUser", "error"); jsl.addClass("uiUsernameError", "hidden"); } }, false); html2.add(formContent, html2.label({ for: "uiViewUser" }, gData.txt.user), gUsernameElem, html2.br({}), html2.p({ id: "uiUsernameError", "class": "ErrorMsg hidden" }, gData.txt.chooseUsername));
        }
        gPassElem = html2.input({ type: "password", tabindex: "2", id: "uiPass", name: "uiPass", onkeyup: function () { if (jsl.hasClass(gPassElem, "error") && "" !== jsl.getValue(gPassElem)) { jsl.removeClass(gPassElem, "error"); jsl.addClass("uiLoginError", "hidden"); } } }); html2.add(formContent, html2.label({ for: "uiPass" }, gData.txt.pass), gPassElem); html2.add(formContent, html2.div({ id: "uiLoginError", "class": "hidden" }, html2.p({ "class": "error_text" }, gData.txt.loginFailed), html2.p({ "class": "error_text" }, gData.txt.mistypedOrNotAuthorized), html2.p({ id: "uiWait", "class": "error_text" }))); if (gData.txt.hintPassword) { html2.add(formContent, html2.div({}, html2.p({ "class": "hintMsg" }, gData.txt.hint_headline), html2.p({}, gData.txt.hintPassword))); }
        if (gData.nbc) { html2.add(formFoot, html2.input({ type: "hidden", name: "nbc", value: "1" })); }
        if (gData.temp_language) { html2.add(formFoot, html2.input({ type: "hidden", name: "temp_language", value: gData.temp_language })); }
        if (gData.dbg) { html2.add(formFoot, html2.input({ type: "hidden", name: "dbg", value: gData.dbg })); }
        html2.add(formFoot, html2.input({ type: "hidden", name: "response", id: "uiResp", value: "" }), html2.input({ type: "hidden", name: "lp", value: gData.lastPage }), html2.input({ type: "hidden", name: "username", id: "username", value: gData.username }), html2.button({ type: "submit", tabindex: "3", id: "submitLoginBtn" }, gData.txt.login)); if (!gData.fromInternet) { html2.add(formFoot, html2.a({ onclick: showForgotPass }, gData.txt.forgotPassword)); }
        return form;
    }
    function createLanguageSelection() {
        var form, formContent, id, txt, divLang; txt = { de: "Bitte wählen Sie Ihre Sprache aus.", en: "Please select your language.", es: "Por favor, seleccione su idioma.", fr: "Veuillez sélectionner votre langue.", it: "Selezionate la vostra lingua.", pl: "Wybierz język." }; form = html2.form({ method: "post", "action": "index.lua" }); html2.add(gDialogContent, form); formContent = html2.div({ "class": "language_selection formular" }); html2.add(form, formContent); divLang = html2.div({}); html2.add(formContent, html2.p({}, txt.en)); gData.languages.forEach(function (lang) {
            if (lang.id !== "en" && lang.currLang) { html2.add(formContent, html2.p({}, txt[lang.id])); }
            id = "uiLanguage:" + lang.id; html2.add(divLang, html2.div({ "class": "formular" }, html2.input({ "type": "radio", name: "temp_language", value: lang.id, checked: lang.currLang, id: id }), html2.label({ "for": id }, lang.name)));
        }); html2.add(formContent, divLang); html2.add(form, html2.div({ "class": "btn_form_foot" }, html2.button({ type: "submit", tabindex: gData.languages.length + 1, id: "submitLangBtn" }, gData.txt.choose)));
    }
    function get_perfTestResult() {
        if (gData.perfTestresults && gData.perfTestresults.MEASURE_ECHO_STATUS !== undefined) {
            if (3 > gData.perfTestresults.MEASURE_ECHO_STATUS) { return 0; }
            if (4 < gData.perfTestresults.MEASURE_ECHO_STATUS) { return 1; }
            if ("number" !== typeof gData.perfTestresults.CABLE_NOK_DISTANCE) { return 2; }
            if (1 > gData.perfTestresults.CABLE_NOK_DISTANCE) { return 3; }
            if (1 <= gData.perfTestresults.CABLE_NOK_DISTANCE && 200 >= gData.perfTestresults.CABLE_NOK_DISTANCE) { return 4; }
            if (200 < gData.perfTestresults.CABLE_NOK_DISTANCE) { return 5; }
        }
        return -1;
    }
    function get_perfTestTxt1(which) {
        var txt, dslDownTime; dslDownTime = gData.perfTestresults.TIME_IN_STATE; txt = jsl.sprintf("Die DSL-Verbindung ist unterbrochen seit %1%Number%.", dslDownTime); switch (which) { case 1: txt += jsl.sprintf(" Die DSL-Leitung wurde getestet: Auf den ersten 200 Metern Leitung ab der FRITZ!Box wurde kein Problem festgestellt (Messung: vor %1%Time%).", gData.perfTestresults.TIME_SINCE_MEASUREMENT); break; case 2: txt += jsl.sprintf(" Die DSL-Leitung wurde getestet: Die Unterbrechung der DSL-Leitung befindet sich innerhalb der ersten 200 Meter Leitung ab der FRITZ!Box (Messung: vor %1%Time%).", gData.perfTestresults.TIME_SINCE_MEASUREMENT); break; case 4: case 5: txt += jsl.sprintf(" Die Unterbrechung der DSL-Leitung befindet sich etwa %1%Number% Meter Leitungslänge von der FRITZ!Box entfernt (Messung: vor %2%Time%).", gData.perfTestresults.CABLE_NOK_DISTANCE, gData.perfTestresults.TIME_SINCE_MEASUREMENT); break; }
        return txt;
    }
    function get_perfTestTxt2(which) {
        var txt; switch (which) { case 0: case 2: case 4: txt = "Bitte prüfen Sie die Verkabelung zur Telefondose (TAE) und die Verkabelung im Haus."; break; case 1: case 5: txt = "Bitte kontaktieren Sie Ihren DSL-Anbieter."; break; case 3: txt = jsl.sprintf("Schließen Sie das DSL-Kabel an die FRITZ!Box an, wenn Sie eine Internetverbindung über DSL aufbauen wollen (Messung: vor %1%Time%).", gData.perfTestresults.TIME_SINCE_MEASUREMENT); break; }
        return txt;
    }
    function doPerfTest() {
        function PerfTestResult(resp) {
            var perfResult; if (resp) {
                gData.perfTestresults = JSON.parse(resp || "{}"); perfResult = get_perfTestResult(); if (perfResult !== -1) { jsl.setText(jsl.get("uiPerfTxt1"), get_perfTestTxt1(perfResult)); jsl.setText(jsl.get("uiPerfTxt2"), get_perfTestTxt2(perfResult)); window.setTimeout(doPerfTest, 15000); } else {
                    if (gXhrDsl) { gXhrDsl.stop(); }
                    jsl.hide("uiPerfTestHead"); jsl.hide("uiPerfTestContent");
                }
            }
        }
        gXhrDsl = http.request({ method: "POST", url: "/", type: "text", params: { dsl: "1" }, callback: PerfTestResult }); gXhrDsl.start();
    }
    function createPerfTestMsg() { var head = html2.div({ class: "perfTestHead", id: "uiPerfTestHead" }), content = html2.div({ class: "perfTestMsg", id: "uiPerfTestContent" }), perfResult = get_perfTestResult(); jsl.setText(head, "Es besteht keine DSL-Verbindung"); head.addEventListener("click", function () { if (jsl.hasClass(head, "show")) { jsl.removeClass(head, "show"); jsl.removeClass(content, "show"); } else { jsl.addClass(head, "show"); jsl.addClass(content, "show"); } }, false); html2.add(head, html2.span({})); html2.add(content, html2.p({ id: "uiPerfTxt1" }, get_perfTestTxt1(perfResult))); html2.add(content, html2.p({ id: "uiPerfTxt2" }, get_perfTestTxt2(perfResult))); html2.add(gDialogContent, head, content); window.setTimeout(doPerfTest, 15000); }
    function showPerfTestResults() {
        var perfResult; if (!gData.fromInternet && gData.perfTestresults) {
            if (gXhrDsl) { gXhrDsl.stop(); }
            perfResult = get_perfTestResult(); if (perfResult !== -1) { createPerfTestMsg(perfResult); }
        }
    }
    function createDialog() { var dialog = null, divContent = null; divContent = html2.div({ id: "dialogContent", "class": "dialog_content" }); dialog = html2.div({ "class": "dialog_outer" }, html2.div({ id: "dialogInner", "class": "dialog_inner" }, html2.div({ id: "dialogHeadBox", "class": "dialog_head_box" }, html2.h2({ id: "dialogTitle" }, gData.pageTitle || "")), divContent)); html2.add(document.body, dialog); return { dialog: dialog, content: divContent }; }
    lib.init = function (data) {
        var dialog = null; if (!jsl || !md5 || !html) { return; }
        gData = data; gData.challenge = gData.challenge || ""; gData.fromInternet = gData.fromInternet || false; if (!gFormElem) {
            dialog = createDialog(); gDialog = dialog.dialog; gDialogContent = dialog.content; if (gData.languages) { gFormElem = createLanguageSelection(); } else { gFormElem = createLoginForm(); }
            showPerfTestResults();
        }
        if (gFormElem) {
            if (!gData.showUser || (gUsernameElem && 0 < gUsernameElem.value.length)) { jsl.enable("submitLoginBtn"); }
            setFocus(); gFormElem.onsubmit = onLoginFormSubmit; if (0 < gData.blockTime) { doBlockLogin(gData.blockTime * 1000); }
        }
    }; return lib;
}());
