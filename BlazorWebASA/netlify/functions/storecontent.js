const fetch = require('node-fetch');

exports.handler = async function(event, context) {

    const { storeid } = event.queryStringParameters;

    if (!storeid) {
        return {
            statusCode: 400,
            body: JSON.stringify({ error: 'Missing storeid' })
        };
    }

    // 构造 Steam API 请求
    const url = `https://store.steampowered.com/api/appdetails?appids=${storeid}`;

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

