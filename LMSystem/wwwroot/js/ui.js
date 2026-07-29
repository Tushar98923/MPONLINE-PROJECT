const NAV_LINKS = [
  { key: 'home', href: 'home.html', icon: 'bi-house-door', label: 'Home' },
  { key: 'dashboard', href: 'dashboard.html', icon: 'bi-speedometer2', label: 'Dashboard' },
  { key: 'books', href: 'books.html', icon: 'bi-book', label: 'Books' },
  { key: 'students', href: 'students.html', icon: 'bi-mortarboard', label: 'Students' },
  { key: 'librarians', href: 'librarians.html', icon: 'bi-person-badge', label: 'Librarians' },
  { key: 'newspapers', href: 'publications.html?type=Newspaper', icon: 'bi-newspaper', label: 'Newspapers' },
  { key: 'magazines', href: 'publications.html?type=Magazine', icon: 'bi-journal-richtext', label: 'Magazines' },
  { key: 'about', href: 'about.html', icon: 'bi-info-circle', label: 'About Us' },
  { key: 'contact', href: 'contact.html', icon: 'bi-envelope', label: 'Contact Us' }
];

function renderShell(activeKey) {
  const user = currentUser();

  const navHtml = NAV_LINKS.map(link => `
    <a href="${link.href}" class="${link.key === activeKey ? 'active' : ''}">
      <i class="bi ${link.icon}"></i><span>${link.label}</span>
    </a>`).join('');

  const sidebarPlaceholder = document.getElementById('sidebarPlaceholder');
  sidebarPlaceholder.innerHTML = `
    <div class="sidebar-backdrop" id="sidebarBackdrop"></div>
    <aside class="sidebar" id="appSidebar">
      <div class="sidebar-brand">
        <i class="bi bi-book-half"></i>
        <span>LMSystem</span>
      </div>
      <nav class="sidebar-nav">${navHtml}</nav>
      <div class="sidebar-footer">
        <div class="user-name"><i class="bi bi-person-circle me-1"></i>${escapeHtml(user || 'Guest')}</div>
        <button class="btn btn-outline-light btn-sm mt-2" id="logoutBtn"><i class="bi bi-box-arrow-right me-1"></i>Logout</button>
      </div>
    </aside>`;

  const topbarPlaceholder = document.getElementById('topbarPlaceholder');
  topbarPlaceholder.innerHTML = `
    <header class="topbar">
      <button class="sidebar-toggle-btn" id="sidebarToggleBtn" aria-label="Toggle navigation">
        <i class="bi bi-list"></i>
      </button>
      <div class="topbar-brand d-lg-none fw-bold">LMSystem</div>
      <div class="topbar-user">
        <span class="text-muted small d-none d-sm-inline">Signed in as</span>
        <strong>${escapeHtml(user || '')}</strong>
      </div>
    </header>`;

  const sidebar = document.getElementById('appSidebar');
  const backdrop = document.getElementById('sidebarBackdrop');
  const toggleBtn = document.getElementById('sidebarToggleBtn');

  const closeSidebar = () => {
    sidebar.classList.remove('show');
    backdrop.classList.remove('show');
  };
  toggleBtn.addEventListener('click', () => {
    sidebar.classList.toggle('show');
    backdrop.classList.toggle('show');
  });
  backdrop.addEventListener('click', closeSidebar);
  sidebar.querySelectorAll('a').forEach(a => a.addEventListener('click', closeSidebar));

  document.getElementById('logoutBtn').addEventListener('click', logout);
}

function showAlert(containerId, message, type = 'danger') {
  const el = document.getElementById(containerId);
  if (!el) return;
  el.innerHTML = `<div class="alert alert-${type} alert-dismissible fade show" role="alert">
    ${escapeHtml(message)}
    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
  </div>`;
}

// Renders Previous / numbered / Next pagination links into containerId.
// pageHref(pageNumber) must return the URL for that page.
function renderPagination(containerId, currentPage, totalPages, pageHref) {
  const el = document.getElementById(containerId);
  if (!el) return;
  if (totalPages <= 1) {
    el.innerHTML = '';
    return;
  }

  let items = `<li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
    <a class="page-link" href="${pageHref(currentPage - 1)}">Previous</a></li>`;

  for (let i = 1; i <= totalPages; i++) {
    items += `<li class="page-item ${currentPage === i ? 'active' : ''}">
      <a class="page-link" href="${pageHref(i)}">${i}</a></li>`;
  }

  items += `<li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
    <a class="page-link" href="${pageHref(currentPage + 1)}">Next</a></li>`;

  el.innerHTML = `<nav aria-label="Page navigation"><ul class="pagination mb-0">${items}</ul></nav>`;
}
