const fetch = require('node-fetch');

exports.handler = async function(event, context) {
    // 读取环境变量
    const apiKey = process.env.STEAM_API_KEY;
    const { steamid } = event.queryStringParameters;

    if (!steamid) {
        return {
            statusCode: 400,
            body: JSON.stringify({ error: 'Missing steamid' })
        };
    }

    // 构造 Steam API 请求
    const url = `https://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v1/?key=${apiKey}&steamid=${steamid}&count=4`;

    try {
        const response = await fetch(url);
        const data = await response.json();
        return {
            statusCode: 200,
            body: JSON.stringify(data)
        };
    } catch (err) {
        return {
            statusCode: 500,
            body: JSON.stringify({ error: 'Steam API request failed' })
        };
    }
};

