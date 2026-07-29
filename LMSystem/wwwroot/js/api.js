const API_BASE = '/api';

class ApiError extends Error {
  constructor(message, status, data) {
    super(message);
    this.status = status;
    this.data = data;
  }
}

function escapeHtml(str) {
  return String(str ?? '').replace(/[&<>"']/g, c => ({
    '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;'
  }[c]));
}

function qs(name) {
  return new URLSearchParams(window.location.search).get(name);
}

function extractErrorMessage(data) {
  if (!data) return null;
  if (data.message) return data.message;
  if (data.errors) {
    const firstKey = Object.keys(data.errors)[0];
    if (firstKey && data.errors[firstKey]?.length) return data.errors[firstKey][0];
  }
  return null;
}

async function apiRequest(method, path, body) {
  const res = await fetch(API_BASE + path, {
    method,
    credentials: 'same-origin',
    headers: body !== undefined ? { 'Content-Type': 'application/json' } : undefined,
    body: body !== undefined ? JSON.stringify(body) : undefined
  });

  if (res.status === 401) {
    if (!location.pathname.endsWith('login.html')) {
      window.location.href = 'login.html';
    }
    throw new ApiError('Not authenticated', 401, null);
  }

  let data = null;
  const text = await res.text();
  if (text) {
    try { data = JSON.parse(text); } catch { data = null; }
  }

  if (!res.ok) {
    throw new ApiError(extractErrorMessage(data) || `Request failed (${res.status})`, res.status, data);
  }

  return data;
}

const api = {
  get: (path) => apiRequest('GET', path),
  post: (path, body) => apiRequest('POST', path, body ?? {}),
  put: (path, body) => apiRequest('PUT', path, body ?? {}),
  del: (path) => apiRequest('DELETE', path)
};
