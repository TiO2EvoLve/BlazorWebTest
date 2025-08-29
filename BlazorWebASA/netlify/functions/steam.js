// netlify/functions/steam.js

export async function handler(event, context) {
    const steamid = event.queryStringParameters.steamid;
    if (!steamid) {
        return { statusCode: 400, body: "Missing steamid" };
    }

    // 🔑 把 API Key 放在 Netlify 环境变量里（安全）
    const apiKey = "1A2472A43F1FE76DF6CEABC658688E5B";
    //const apiKey = process.env.STEAM_API_KEY;

    const url = `https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=${apiKey}&steamids=${steamid}`;

    try {
        const response = await fetch(url);
        const data = await response.json();

        return {
            statusCode: 200,
            body: JSON.stringify(data),
            headers: { "Content-Type": "application/json" }
        };
    } catch (err) {
        return { statusCode: 500, body: "Error: " + err.message };
    }
}
