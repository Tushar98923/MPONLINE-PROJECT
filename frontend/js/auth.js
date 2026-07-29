let cachedUser = null;

async function requireLogin() {
  try {
    const res = await api.get('/auth/me');
    cachedUser = res.username;
    return cachedUser;
  } catch (err) {
    if (err.status === 401) {
      // apiRequest already redirected to login.html - hang here so callers
      // never resume with an unauthenticated page still rendering.
      return new Promise(() => {});
    }
    console.error(err);
    throw err;
  }
}

function currentUser() {
  return cachedUser;
}

async function logout() {
  try {
    await api.post('/auth/logout');
  } catch (err) {
    // ignore - we're navigating to the login page regardless
  }
  window.location.href = 'login.html';
}
