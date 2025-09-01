// ...existing code...
export async function getSteamUser(steamid) {
  const response = await fetch(`/.netlify/functions/steam-proxy?steamid=${steamid}`);
  return await response.json();
}
// ...existing code...

