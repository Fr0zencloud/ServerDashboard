window.onload = function () {
    //infos
    let os_txt = document.getElementById("os");
    let machine_txt = document.getElementById("server-select").children[1].children[0]
    let cpu_txt = document.getElementById("cpu");
    let ram_txt = document.getElementById("ram");
    let disk_txt = document.getElementById("diskspace");

    //tiles
    let discord = document.getElementById("tile_discord");
    let jira = document.getElementById("tile_jira");
    let minecraft = document.getElementById("tile_minecraft");

    /*
    discord.addEventListener("click", function () { start("discord", discord); }, false);
    jira.addEventListener("click", function () { start("jira", jira); }, false);
    minecraft.addEventListener("click", function () { start("minecraft@vanilla", minecraft); }, false);
*/
    let url = "http://localhost:3000/system/info/";

    function firstToUpper(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    function setTileColor(tile, color) {
        tile.classList.remove(tile.classList.item(tile.classList.length - 1));
        tile.classList.add(color);
    }

    function setTileText(tile, text) {
        tile.children[2].innerText = firstToUpper(text);
    }

    function updateTileStatus(tile, data) {
        if (data === "running") {
            setTileColor(tile, "green");
        } else if (data.valueOf() === "starting") {
            setTileColor(tile, "yellow");
        } else if (data.valueOf() === "stopped") {
            setTileColor(tile, "red");
        }
        setTileText(tile, data);
    }

    function getInfos() {
        $.getJSON(url, function (data) {
            //updateTileStatus(jira, data.Jira);
            //updateTileStatus(minecraft, data.Minecraft);
            os_txt.innerText = "OS: " + data.platform;
            machine_txt.innerText = data.hostname;
            cpu_txt.innerText = "CPU: " + data.cpu;
            ram_txt.innerText = "RAM: " + data.freeMemory + "/" + data.totalMemory + "Gb";
            disk_txt.innerText = "Disk: " + Math.round(data.diskFree) + "GB free of " + Math.round(data.diskTotal) + "GB";
        });
        setTimeout(getInfos, 10000);
    }
    getInfos();

    function start(task, tile) {
        $.getJSON("http://31.172.80.113:8010/system/start?task=" + task);
        setTileColor(tile, "yellow");
        setTileText(tile, "starting...");
    }
}